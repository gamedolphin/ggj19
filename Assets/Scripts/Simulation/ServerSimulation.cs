using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using Zenject;
using ZeroFormatter;
using System.Linq;
using UniRx;
using System;

[ZeroFormattable]
public class WorldState {
    [Index(0)]
    public virtual IList<PlayerState> PlayerList { get; set; }
    [Index(1)]
    public virtual IList<QuestInfo> QuestList { get; set; }
    [Index(2)]
    public virtual IList<EnemyInfo> EnemyList {get; set; }
}

public class PlayerScore {
    public string name;
    public float score;
}

namespace Server {

    public class ServerSimulation  : IFixedTickable, IDisposable  {

        private struct InputInfo {
            public int Hashcode;
            public InputData Data;
        }

        private int totalQuestItems = 0;
        private int totalEnemyItems = 0;

        public Dictionary<int, SimulationPlayer> playerDic = new Dictionary<int, SimulationPlayer>();
        public List<SimulationPlayer> playerList =  new List<SimulationPlayer>();
        public List<QuestItem> questList = new List<QuestItem>();
        public List<EnemyItem> enemyList = new List<EnemyItem>();

        private SimulationPlayer.Factory simFactory;
        private QuestItem.Factory questFactory;
        private EnemyItem.Factory enemyFactory;
        private List<Transform> spawnPoints;

        private Queue<InputInfo> networkInput = new Queue<InputInfo>();
        private CompositeDisposable disp = new CompositeDisposable();

        public ServerSimulation(SimulationPlayer.Factory playerFactory, QuestItem.Factory qFac, EnemyItem.Factory eFac, List<Transform> spP, MeteorManager meteor) {
            simFactory = playerFactory;
            spawnPoints = spP;
            questFactory = qFac;
            enemyFactory = eFac;

            Observable.Interval(TimeSpan.FromSeconds(5))
                .Select(_ => {
                        var info = playerList.Select(p => new PlayerScore {
                                name = p.Name,
                                score = p.Score
                            });
                        return info.ToList();
                    })
                .SelectMany(scores => {
                        return meteor.UpdateScore(scores);
                    })
                .Subscribe(_ => Debug.Log(_))
                .AddTo(disp);
        }

        public void Dispose() {
            disp.Dispose();
        }

        public void AddPlayer(int hashcode, string Name, NetPeer peer) {
            var player = simFactory.Create(hashcode, Name);
            var randomTransform = spawnPoints[UnityEngine.Random.RandomRange(0, spawnPoints.Count - 1)];
            Debug.Log("SPAWING AT "+randomTransform.position);
            player.transform.position = randomTransform.position;
            playerDic.Add(hashcode, player);
            playerList.Add(player);
        }

        public void FixedTick() {
            while(networkInput.Count > 0) {
                var info = networkInput.Dequeue();
                playerDic[info.Hashcode].UpdateInput(info.Data);
            }
        }

        public void RemovePlayer(int id) {
            GameObject.Destroy(playerDic[id].gameObject);
            playerDic.Remove(id);
            playerList.RemoveAll(p => p.Hashcode == id);
        }

        public void AddInput(int id, InputData data) {
            networkInput.Enqueue(new InputInfo {
                    Hashcode = id,
                    Data = data
                });
        }

        public void SpawnQuest(QuestItem questPrefab) {
            var item = questFactory.Create(questPrefab);
            item.PlaceSelf(totalQuestItems++);
            questList.Add(item);
        }

        public void DespawnQuest (QuestItem item, List<int> playerIds) {
            questList.Remove(item);

            playerIds.ForEach(p => {
                    playerDic[p].UpdateScore(item.Points);
                });
        }

        public void SpawnEnemy(EnemyItem enemyPrefab) {
            var enemy = enemyFactory.Create(enemyPrefab);
            enemy.PlaceSelf(totalEnemyItems++);
            enemyList.Add(enemy);
        }

        public WorldState GetWorldState () {
            var playerStates = playerList.Select(p => p.GetPlayerState());
            var questStates = questList.Select(q => q.GetQuestState());
            var enemyStates = enemyList.Select(q => q.GetEnemyState());
            return new WorldState {
                PlayerList = playerStates.ToArray(),
                QuestList = questStates.ToArray(),
                EnemyList = enemyStates.ToArray()
            };
        }
    }

}

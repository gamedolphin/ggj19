using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using Zenject;
using ZeroFormatter;
using System.Linq;

[ZeroFormattable]
public class WorldState {
    [Index(0)]
    public virtual IList<PlayerState> PlayerList { get; set; }
}

namespace Server {

    public class ServerSimulation  : IFixedTickable  {

        private struct InputInfo {
            public long Id;
            public InputData Data;
        }

        public Dictionary<long, SimulationPlayer> playerDic = new Dictionary<long, SimulationPlayer>();
        public List<SimulationPlayer> playerList =  new List<SimulationPlayer>();

        private SimulationPlayer.Factory simFactory;
        private List<Transform> spawnPoints;

        private Queue<InputInfo> networkInput = new Queue<InputInfo>();

        public ServerSimulation(SimulationPlayer.Factory playerFactory, List<Transform> spP) {
            simFactory = playerFactory;
            spawnPoints = spP;
        }

        public void AddPlayer(long id, NetPeer peer) {
            var player = simFactory.Create(peer.Id);
            var randomTransform = spawnPoints[Random.RandomRange(0, spawnPoints.Count - 1)];
            Debug.Log("SPAWING AT "+randomTransform.position);
            player.transform.position = randomTransform.position;
            playerDic.Add(id, player);
            playerList.Add(player);
        }

        public void FixedTick() {
            while(networkInput.Count > 0) {
                var info = networkInput.Dequeue();
                playerDic[info.Id].UpdateInput(info.Data);
            }
        }

        public void RemovePlayer(long id) {
            GameObject.Destroy(playerDic[id].gameObject);
            playerDic.Remove(id);
            playerList.RemoveAll(p => p.Id == id);
        }

        public void AddInput(long id, InputData data) {
            networkInput.Enqueue(new InputInfo {
                    Id = id,
                    Data = data
                });
        }

        public WorldState GetWorldState () {
            var playerStates = playerList.Select(p => p.GetPlayerState());
            return new WorldState {
                PlayerList = playerStates.ToArray()
            };
        }
    }

}

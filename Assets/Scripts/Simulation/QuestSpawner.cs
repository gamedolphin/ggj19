using System.Collections.Generic;
using UniRx;
using System;
using Zenject;
using System.Linq;
using UnityEngine;
using Server;
using ZeroFormatter;

[ZeroFormattable]
public struct QuestInfo {
    [Index(0)]
    public string QuestName;
    [Index(1)]
    public Vector3Sim Position;
    [Index(2)]
    public float Health;
    [Index(3)]
    public int Id;

    public QuestInfo(string qname, Vector3Sim pos, float h, int id) {
        QuestName = qname;
        Id = id;
        Position = pos;
        Health = h;
    }

    public Vector3 GetPosition () {
        return new Vector3(Position.x, Position.y, Position.z);
    }
}

[System.Serializable]
public class QuestSettings {
    public QuestItem questPrefab;
    public int MaxCount;
}

public class QuestSpawner : IInitializable, IDisposable {

    private List<QuestSettings> QuestList;
    private CompositeDisposable disposable = new CompositeDisposable();

    private Dictionary<string,int> QuestItemCounts = new Dictionary<string,int>();

    private ServerSimulation serverSimulation;

    public QuestSpawner(List<QuestSettings> quests, ServerSimulation sim) {
        QuestList = quests;
        serverSimulation = sim;
    }

    public void Initialize() {
        QuestList.ForEach(q => {
                QuestItemCounts.Add(q.questPrefab.QuestName, 0);
            });

        Observable.Interval(TimeSpan.FromSeconds(2))
            .Subscribe(_ => SpawnQuest())
            .AddTo(disposable);

    }

    public void Dispose() {
        disposable.Dispose();
    }

    public void SpawnQuest() {
        var availableQuests = QuestList.Where(quest => {
                var count = QuestItemCounts[quest.questPrefab.QuestName];
                return count < quest.MaxCount;
            });

        if(availableQuests.Count() > 0) {
            var questToSpawn = availableQuests.ElementAt(UnityEngine.Random.Range(0,availableQuests.Count() - 1));

            serverSimulation.SpawnQuest(questToSpawn.questPrefab);

            QuestItemCounts[questToSpawn.questPrefab.QuestName]++;
        }
    }

    public void DespawnQuest(QuestItem item) {
        QuestItemCounts[item.QuestName] -= 1;
    }
}

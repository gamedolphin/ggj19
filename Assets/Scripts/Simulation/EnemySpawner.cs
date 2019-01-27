using System.Collections.Generic;
using UniRx;
using System;
using Zenject;
using System.Linq;
using UnityEngine;
using Server;
using ZeroFormatter;

[ZeroFormattable]
public struct EnemyInfo {
    [Index(0)]
    public string EnemyName;
    [Index(1)]
    public Vector3Sim Position;
    [Index(2)]
    public int Id;

    public EnemyInfo(string qname, Vector3Sim pos, int id) {
        EnemyName = qname;
        Id = id;
        Position = pos;
    }

    public Vector3 GetPosition () {
        return new Vector3(Position.x, Position.y, Position.z);
    }
}

[System.Serializable]
public class EnemySettings {
    public EnemyItem questPrefab;
    public int Count;
}

public class EnemySpawner : IInitializable, IDisposable {

    private List<EnemySettings> EnemyList;
    private ServerSimulation serverSimulation;

    public EnemySpawner(List<EnemySettings> enemies, ServerSimulation sim) {
        EnemyList = enemies;
        serverSimulation = sim;
    }

    public void Initialize() {
        EnemyList.ForEach(enemySetting => {
                for (int i=0; i < enemySetting.Count; ++i) {
                    serverSimulation.SpawnEnemy(enemySetting.questPrefab);
                }
            });
    }

    public void Dispose() {

    }

}

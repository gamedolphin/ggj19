using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class SpawnPointInstaller : MonoInstaller
{

    [SerializeField] private List<Transform> spawnPoints;

    public override void InstallBindings()
    {
        Container.BindInstance(spawnPoints).AsSingle();
    }
}

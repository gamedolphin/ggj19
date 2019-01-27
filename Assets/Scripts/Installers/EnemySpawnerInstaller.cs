using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class EnemySpawnerInstaller : MonoInstaller
{

    [SerializeField] private List<EnemySettings> settings;

    public override void InstallBindings()
    {
        Container.BindInstance(settings).AsSingle();
        Container.BindFactory<UnityEngine.Object, EnemyItem, EnemyItem.Factory>().FromFactory<PrefabFactory<EnemyItem>>();
        Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().NonLazy();
    }
}

using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class QuestSpawnerInstaller : MonoInstaller
{

    [SerializeField] private List<QuestSettings> settings;

    public override void InstallBindings()
    {
        Container.BindInstance(settings).AsSingle();
        Container.BindFactory<UnityEngine.Object, QuestItem, QuestItem.Factory>().FromFactory<PrefabFactory<QuestItem>>();
        Container.BindInterfacesAndSelfTo<QuestSpawner>().AsSingle().NonLazy();
    }
}

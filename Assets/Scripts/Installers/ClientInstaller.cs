using UnityEngine;
using Zenject;
using Client;
using System.Collections.Generic;

[System.Serializable]
public class QuestItemListInfo {
    public string Name;
    public QuestItemClient Item;
}

[System.Serializable]
public class EnemyItemListInfo {
    public string Name;
    public EnemyItemClient Item;
}

[CreateAssetMenu(fileName = "ClientInstaller", menuName = "Installers/ClientInstaller")]
public class ClientInstaller : ScriptableObjectInstaller<ClientInstaller> {

    [SerializeField] private ClientNetworkSettings networkSettings;
    [SerializeField] private ClientSimulationEntity playerPrefab;
    [SerializeField] private ClientSimulationEntity otherPlayerPrefab;

    [SerializeField] private List<QuestItemListInfo> questItemList;
    [SerializeField] private List<EnemyItemListInfo> enemyItemList;

    public override void InstallBindings() {

        var questItemDic = new Dictionary<string,QuestItemClient>();
        questItemList.ForEach(info => {
                questItemDic.Add(info.Name,info.Item);
            });

        var enemyItemDic = new Dictionary<string,EnemyItemClient>();
        enemyItemList.ForEach(info => {
                enemyItemDic.Add(info.Name,info.Item);
            });


        Container.BindFactory<int, ClientSimulationPlayer, ClientSimulationPlayer.Factory>().FromComponentInNewPrefab(playerPrefab);
        Container.BindFactory<int, ClientSimulationOtherPlayers, ClientSimulationOtherPlayers.Factory>().FromComponentInNewPrefab(otherPlayerPrefab);
        Container.BindInterfacesAndSelfTo<ClientSimulation>().AsSingle();
        Container.BindInstance(networkSettings);
        Container.BindInstance(questItemDic).AsSingle();
        Container.BindInstance(enemyItemDic).AsSingle();
        Container.BindFactory<UnityEngine.Object, QuestItemClient, QuestItemClient.Factory>().FromFactory<PrefabFactory<QuestItemClient>>();
        Container.BindFactory<UnityEngine.Object, EnemyItemClient, EnemyItemClient.Factory>().FromFactory<PrefabFactory<EnemyItemClient>>();
        Container.BindInterfacesAndSelfTo<ClientNetworkManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
    }
}

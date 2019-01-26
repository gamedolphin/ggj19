using UnityEngine;
using Zenject;
using Server;

[CreateAssetMenu(fileName = "ServerInstaller", menuName = "Installers/ServerInstaller")]
public class ServerInstaller : ScriptableObjectInstaller<ServerInstaller> {

    [SerializeField] private ServerNetworkSettings networkSettings;
    [SerializeField] private SimulationPlayer playerPrefab;

    public override void InstallBindings() {
        Container.BindFactory<int, SimulationPlayer, SimulationPlayer.Factory>().FromComponentInNewPrefab(playerPrefab);
        Container.BindInterfacesAndSelfTo<ServerSimulation>().AsSingle();
        Container.BindInstance(networkSettings).AsSingle();
        Container.BindInterfacesAndSelfTo<ServerNetworkManager>().AsSingle().NonLazy();
    }
}

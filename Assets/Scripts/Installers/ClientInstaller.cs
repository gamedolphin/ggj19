using UnityEngine;
using Zenject;
using Client;

[CreateAssetMenu(fileName = "ClientInstaller", menuName = "Installers/ClientInstaller")]
public class ClientInstaller : ScriptableObjectInstaller<ClientInstaller> {

    [SerializeField] private ClientNetworkSettings networkSettings;
    [SerializeField] private ClientSimulationPlayer playerPrefab;

    public override void InstallBindings() {
        Container.BindFactory<long, ClientSimulationPlayer, ClientSimulationPlayer.Factory>().FromComponentInNewPrefab(playerPrefab);
        Container.BindInterfacesAndSelfTo<ClientSimulation>().AsSingle();
        Container.BindInstance(networkSettings);
        Container.BindInterfacesAndSelfTo<ClientNetworkManager>().AsSingle().NonLazy();
    }
}

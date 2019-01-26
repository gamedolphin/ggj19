using UnityEngine;
using Zenject;
using Client;

[CreateAssetMenu(fileName = "ClientInstaller", menuName = "Installers/ClientInstaller")]
public class ClientInstaller : ScriptableObjectInstaller<ClientInstaller> {

    [SerializeField] private ClientNetworkSettings networkSettings;
    [SerializeField] private ClientSimulationEntity playerPrefab;
    [SerializeField] private ClientSimulationEntity otherPlayerPrefab;

    public override void InstallBindings() {

        Container.BindFactory<long, ClientSimulationPlayer, ClientSimulationPlayer.Factory>().FromComponentInNewPrefab(playerPrefab);
        Container.BindFactory<long, ClientSimulationOtherPlayers, ClientSimulationOtherPlayers.Factory>().FromComponentInNewPrefab(otherPlayerPrefab);
        Container.BindInterfacesAndSelfTo<ClientSimulation>().AsSingle();
        Container.BindInstance(networkSettings);
        Container.BindInterfacesAndSelfTo<ClientNetworkManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
    }
}

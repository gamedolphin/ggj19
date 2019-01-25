using UnityEngine;
using Zenject;
using Client;

[CreateAssetMenu(fileName = "ClientInstaller", menuName = "Installers/ClientInstaller")]
public class ClientInstaller : ScriptableObjectInstaller<ClientInstaller> {

    [SerializeField] private ClientNetworkSettings networkSettings;

    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<ClientNetworkManager>().AsSingle().WithArguments(networkSettings).NonLazy();
    }
}

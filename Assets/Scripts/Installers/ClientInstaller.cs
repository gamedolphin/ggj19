using UnityEngine;
using Zenject;
using Client;

[CreateAssetMenu(fileName = "ClientInstaller", menuName = "Installers/ClientInstaller")]
public class ClientInstaller : ScriptableObjectInstaller<ClientInstaller> {

    [SerializeField] private ClientNetworkSettings networkSettings;
    [SerializeField] private RestClientSettings restClientSettings;

    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<ClientNetworkManager>().AsSingle().WithArguments(networkSettings).NonLazy();
        Container.Bind<RestClientManager>().AsSingle().WithArguments(restClientSettings).NonLazy();
        Container.Bind<IRestClient>().To<UniRxRestClient>().FromNew().AsSingle();
    }
}

using UnityEngine;
using Zenject;
using Server;

[CreateAssetMenu(fileName = "ServerInstaller", menuName = "Installers/ServerInstaller")]
public class ServerInstaller : ScriptableObjectInstaller<ServerInstaller> {

    [SerializeField] private ServerNetworkSettings networkSettings;

    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<ServerNetworkManager>().AsSingle().WithArguments(networkSettings).NonLazy();
    }
}

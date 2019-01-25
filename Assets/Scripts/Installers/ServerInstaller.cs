using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ServerInstaller", menuName = "Installers/ServerInstaller")]
public class ServerInstaller : ScriptableObjectInstaller<ServerInstaller>
{
    public override void InstallBindings()
    {
    }
}
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MeteorInstaller", menuName = "Installers/MeteorInstaller")]
public class MeteorInstaller : ScriptableObjectInstaller<MeteorInstaller>
{

    [SerializeField] private string meteorUrl;

    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<MeteorManager>().AsSingle().WithArguments(meteorUrl).NonLazy();
    }
}

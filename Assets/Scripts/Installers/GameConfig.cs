using UnityEngine;
using Zenject;

public enum GameType {
    CLIENT, SERVER
}

[CreateAssetMenu(fileName = "GameConfig", menuName = "Installers/GameConfig")]
public class GameConfig : ScriptableObjectInstaller<GameConfig> {

    [SerializeField] private GameType gameType;
    [SerializeField] private ScriptableObjectInstaller serverInstaller;
    [SerializeField] private ScriptableObjectInstaller clientInstaller;


    public override void InstallBindings() {

        if(gameType == GameType.SERVER) {
            Container.Inject(serverInstaller);
            serverInstaller.InstallBindings();
        }
        else if(gameType == GameType.CLIENT) {
            Container.Inject(clientInstaller);
            clientInstaller.InstallBindings();
        }
    }

    public void RunServer() {
        #if UNITY_EDITOR
        gameType = GameType.SERVER;
        UnityEditor.EditorApplication.isPlaying = true;
        #endif
    }

    public void RunClient() {
        #if UNITY_EDITOR
        gameType = GameType.CLIENT;
        UnityEditor.EditorApplication.isPlaying = true;
        #endif
    }
}

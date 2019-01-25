using UnityEngine;
using Zenject;

public enum GameType {
    CLIENT, SERVER
}

[CreateAssetMenu(fileName = "GameConfig", menuName = "Installers/GameConfig")]
public class GameConfig : ScriptableObjectInstaller<GameConfig> {

    [SerializeField] private GameType gameType;

    public override void InstallBindings() {
    }
}

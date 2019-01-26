using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public Button playButton;
    public InputField userName;
    public string MainScene;

    private void Start() {
        playButton.OnClickAsObservable()
            .Subscribe(_ => {
                if (!string.IsNullOrWhiteSpace(userName.text)) {
                    PlayerPrefs.SetString("userName", userName.text);
                    playButton.interactable = false;
                    SceneManager.LoadSceneAsync(MainScene);
                }
            });
    }
}

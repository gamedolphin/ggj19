using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public const string userName = "userName";

    public Button playButton;
    public InputField userNameField;
    public string LobbyScene;

    private void Awake() {
        userNameField.text = PlayerPrefs.GetString(userName);
        if (string.IsNullOrWhiteSpace(userNameField.text)) {
            playButton.interactable = false;
        } else {
            playButton.interactable = true;
        }
    }

    private void Start() {
        userNameField.OnValueChangedAsObservable()
            .Subscribe(name => {
                if (string.IsNullOrWhiteSpace(name) || name.Length > 10) {
                    playButton.interactable = false;
                } else {
                    playButton.interactable = true;
                }
            });

        playButton.OnClickAsObservable()
            .Subscribe(_ => {
                if (!string.IsNullOrWhiteSpace(userNameField.text)) {
                    playButton.interactable = false;
                    PlayerPrefs.SetString(userName, userNameField.text);
                    SceneManager.LoadSceneAsync(LobbyScene);
                }
            });
    }
}

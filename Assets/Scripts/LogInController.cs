using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LogInController : MonoBehaviour {
    public Button SignInButton;
    public Button SignUpButton;
    public InputField UserNameField;
    public InputField PasswordField;

    public bool isUserSignedIn;

    [Inject] private IRestClient restClient;
    [Inject] private RestClientManager restClientManger;

    // Start is called before the first frame update
    void Start() {
        SignInButton.OnClickAsObservable()
            .Do(_ => {
                SignInButton.interactable = false;
                SignUpButton.interactable = false;
            })
            .SelectMany(_ => SignInUser(UserNameField.text, PasswordField.text))
            .CatchIgnore((WWWErrorException ex) => {
                SignInButton.interactable = true;
                SignUpButton.interactable = true;
            })
            .Subscribe(SetSignInData);

        SignUpButton.OnClickAsObservable()
            .Do(_ => {
                SignInButton.interactable = false;
                SignUpButton.interactable = false;
            })
            .SelectMany(_ => SignUpUser(UserNameField.text, PasswordField.text))
            .CatchIgnore((WWWErrorException ex) => {
                SignInButton.interactable = true;
                SignUpButton.interactable = true;
            })
            .Subscribe(SetSignInData);
    }

    public IObservable<UserBackEndData> SignInUser(string userName, string password) {
        string requestUrl = restClientManger.ip + "/signin";
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("password", password);

        return restClient.Post(requestUrl, form)
            .SelectMany(data => Observable.Start(() => JsonUtility.FromJson<UserBackEndData>(data)))
            .ObserveOnMainThread();
    }

    public IObservable<UserBackEndData> SignUpUser(string userName, string password) {
        string requestUrl = restClientManger.ip + "/signup";
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("password", password);

        return restClient.Post(requestUrl, form)
            .SelectMany(data => Observable.Start(() => JsonUtility.FromJson<UserBackEndData>(data)))
            .ObserveOnMainThread();
    }

    public void SetSignInData(UserBackEndData data) {
        isUserSignedIn = true;
        PlayerPrefs.SetString("UserToken", data.userToken);
    }

}

public class UserBackEndData {
    public string userToken;
    
}

public class UserLoginData {
    public string userName;
    public string password;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatInputController : MonoBehaviour
{
    public GameObject parentPanel;
    public bool isChatActive = false;
    public InputField message;
    public Text userNameText;

    // Start is called before the first frame update
    void Start()
    {
        userNameText.text = PlayerPrefs.GetString("userName");
        parentPanel.SetActive(isChatActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)) {
            isChatActive = !isChatActive;
            parentPanel.SetActive(isChatActive);
            if(!isChatActive && !string.IsNullOrWhiteSpace(message.text)) {
                //send message to server
                Debug.Log($"{message.text}");
            }
            else if (isChatActive) {
                message.ActivateInputField();
            }
            message.text = string.Empty;
        }
    }
}

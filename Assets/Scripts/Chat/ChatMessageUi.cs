using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.UI;

public class ChatMessageUi : MonoBehaviour
{
    [SerializeField] private Text userName;

    public string Text1;
    public string Text2;

    public void Initialize(string usrname, string msg) {
        Text1 = usrname;
        Text2 = msg;
        userName.text = $"{usrname}: {msg}";
    }
}

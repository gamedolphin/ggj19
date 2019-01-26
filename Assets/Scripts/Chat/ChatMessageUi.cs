using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.UI;

public class ChatMessageUi : MonoBehaviour
{
    [SerializeField] private Text userName;

    public void Initialize(string usrname, string msg) {
        userName.text = $"{usrname}: {msg}";
    }
}

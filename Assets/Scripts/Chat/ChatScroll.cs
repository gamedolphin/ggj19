using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class ChatScroll : MonoBehaviour
{
    [Inject] private MeteorManager meteor;

    [SerializeField] private string roomName;
    [SerializeField] private ChatMessageUi msgPrefab;
    [SerializeField] private Transform scrollContent;

    private List<ChatMessageUi> msgList = new List<ChatMessageUi>();

    private void Start() {
        meteor.connected
            .Where(c => c == true)
            .SelectMany(c => meteor.SubscribeToChat(roomName))
            .SelectMany(c => meteor.WatchChat())
            .TakeUntilDestroy(this)
            .Subscribe(chat => {
                    var obj = Instantiate(msgPrefab,scrollContent);
                    obj.Initialize(chat.username, chat.msg);

                    msgList.Add(obj);

                    if(msgList.Count > 20) {
                        var del = msgList[0];
                        msgList.RemoveAt(0);
                        GameObject.Destroy(del.gameObject);
                    }
                });
    }

    private void OnDestroy() {
        meteor.UnsubscribeToChat();
    }
}

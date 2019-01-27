using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    [Inject] private MeteorManager meteor;

    [SerializeField] private ChatMessageUi msgPrefab;
    [SerializeField] private Transform scrollContent;

    private List<ChatMessageUi> msgList = new List<ChatMessageUi>();

    private void Start() {
        meteor.connected
            .Where(c => c == true)
            .SelectMany(c => meteor.SubscribeToLeader())
            .SelectMany(c => meteor.WatchScores())
            .TakeUntilDestroy(this)
            .Subscribe(chat => {

                    var already = msgList.Find(m => {
                            return m.Text1 == chat.name;
                        });

                    if(already) {
                        already.Initialize(chat.name, chat.score.ToString());
                    }
                    else {
                        var obj = Instantiate(msgPrefab,scrollContent);
                        Debug.Log(chat.name);
                        obj.Initialize(chat.name, chat.score.ToString());

                        msgList.Add(obj);

                        if(msgList.Count > 20) {
                            var del = msgList[0];
                            msgList.RemoveAt(0);
                            GameObject.Destroy(del.gameObject);
                        }
                    }
                });
    }

    private void OnDestroy() {
        meteor.UnsubscribeToLeader();
    }
}

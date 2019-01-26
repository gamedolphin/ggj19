using Meteor;
using Zenject;
using UniRx;
using System.Collections;
using System;
using UnityEngine;

public class ChatData : Meteor.MongoDocument {
    public string username;
    public string msg;
    public string room;
}

public class MeteorManager {


    private string meteorUrl;
    public ReactiveProperty<bool> connected = new ReactiveProperty<bool>(false);
    private Meteor.Collection<ChatData> collection;


    public MeteorManager(string mUrl) {
        meteorUrl = mUrl;
        Observable.FromCoroutine(Connect)
            .Subscribe(_ => {
                    Debug.Log("CONNECTED");
                    connected.Value = true;
                    collection = new Meteor.Collection<ChatData> ("messages");
                });
    }

    private IEnumerator Connect() {
        yield return Meteor.Connection.Connect ($"ws://{meteorUrl}/websocket");
    }

    public IObservable<bool> SendChat(string msg, string room) {
        return Observable.FromCoroutine<bool>((observer, cancellationToken) => {
                return SendChat(msg, room, observer);
            });
    }

    public IObservable<ChatData> WatchChat() {
        return Observable.Create<ChatData>((IObserver<ChatData> observer) => {
                collection.Find().Observe(added: (string id, ChatData doc) => {
                        observer.OnNext(doc);
                    });
                return Disposable.Create(() => {});
            });
    }

    public IObservable<bool> SubscribeToChat(string room) {
        return Observable.FromCoroutine<bool>((observer, cancellationToken) => SubscribeToChat(room, observer));
    }

    public void UnsubscribeToChat() {
        Meteor.Subscription.Unsubscribe("chatRoom");
    }

    private IEnumerator SubscribeToChat(string room, IObserver<bool> observer) {
        var subscription = Meteor.Subscription.Subscribe ("chatRoom", room);
        yield return (Coroutine)subscription;
        observer.OnNext(true);
        observer.OnCompleted();
    }

    private IEnumerator SendChat(string msg, string room, IObserver<bool> observer) {
        var username = PlayerPrefs.GetString("userName");

        Debug.Log(username);

        if(string.IsNullOrEmpty(username)) {
            observer.OnNext(false);
            observer.OnCompleted();
        }

        var methodCall = Meteor.Method<bool>.Call ("sendMessage", room, msg, username);

        yield return (Coroutine)methodCall;

        observer.OnNext(true);
        observer.OnCompleted();
    }
}

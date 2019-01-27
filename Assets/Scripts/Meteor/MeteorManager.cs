using Meteor;
using Zenject;
using UniRx;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class ChatData : Meteor.MongoDocument {
    public string username;
    public string msg;
    public string room;
    public long createdAt;
}

public class ScoreData : Meteor.MongoDocument {
    public string name;
    public float score;
}

public class MeteorManager {


    private string meteorUrl;
    public ReactiveProperty<bool> connected = new ReactiveProperty<bool>(false);
    private Meteor.Collection<ChatData> collection;
    private Meteor.Collection<ScoreData> scoreboard;


    public MeteorManager(string mUrl) {
        meteorUrl = mUrl;
        Observable.FromCoroutine(Connect)
            .Subscribe(_ => {
                    Debug.Log("CONNECTED");
                    connected.Value = true;
                });
        collection = new Meteor.Collection<ChatData> ("messages");
        scoreboard = new Meteor.Collection<ScoreData>("scores");
    }

    private IEnumerator Connect() {
        yield return Meteor.Connection.Connect ($"ws://{meteorUrl}/websocket");
    }

    public IObservable<bool> SendChat(string msg, string room) {
        return Observable.FromCoroutine<bool>((observer, cancellationToken) => {
                return SendChat(msg, room, observer);
            });
    }

    public IObservable<ScoreData> WatchScores() {
        return Observable.Create<ScoreData>((IObserver<ScoreData> observer) => {
                scoreboard.Find().Observe(added: (string id, ScoreData doc) => {
                        observer.OnNext(doc);
                    }, changed: (string id, ScoreData doc, IDictionary d, string[] str) => {
                        observer.OnNext(doc);
                    });
                return Disposable.Create(() => {});
            });
    }

    public IObservable<ChatData> WatchChat() {
        long t = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        return Observable.Create<ChatData>((IObserver<ChatData> observer) => {
                collection.Find().Observe(added: (string id, ChatData doc) => {
                        if(doc.createdAt > t) {
                            observer.OnNext(doc);
                        }
                    });
                return Disposable.Create(() => {});
            });
    }

    public IObservable<bool> SubscribeToChat(string room) {
        return Observable.FromCoroutine<bool>((observer, cancellationToken) => SubscribeToChat(room, observer));
    }

    public IObservable<bool> SubscribeToLeader() {
        return Observable.FromCoroutine<bool>((observer, cancellationToken) => SubscribeToLeader(observer));
    }

    public void UnsubscribeToChat() {
        Meteor.Subscription.Unsubscribe("chatRoom");
    }

    public void UnsubscribeToLeader() {
        Meteor.Subscription.Unsubscribe("scoreboard");
    }

    public IObservable<bool> UpdateScore(List<PlayerScore> scores) {
        return Observable.FromCoroutine<bool>((observer, cancellationToken) => {
                return UpdateScore(scores, observer);
            });
    }

    private IEnumerator SubscribeToChat(string room, IObserver<bool> observer) {
        var subscription = Meteor.Subscription.Subscribe ("chatRoom", room);
        yield return (Coroutine)subscription;
        observer.OnNext(true);
        observer.OnCompleted();
    }


    private IEnumerator SubscribeToLeader(IObserver<bool> observer) {
        var subscription = Meteor.Subscription.Subscribe ("scoreboard");
        yield return (Coroutine)subscription;
        observer.OnNext(true);
        observer.OnCompleted();
    }

    private IEnumerator SendChat(string msg, string room, IObserver<bool> observer) {
        var username = PlayerPrefs.GetString("userName");

        if(string.IsNullOrEmpty(username)) {
            observer.OnNext(false);
            observer.OnCompleted();
        }

        var methodCall = Meteor.Method<bool>.Call ("sendMessage", room, msg, username);

        yield return (Coroutine)methodCall;

        observer.OnNext(true);
        observer.OnCompleted();
    }

    private IEnumerator UpdateScore(List<PlayerScore> scores, IObserver<bool> observer) {
        var methodCall = Meteor.Method<bool>.Call ("updateScore", scores);

        yield return (Coroutine)methodCall;

        observer.OnNext(true);
        observer.OnCompleted();
    }
}

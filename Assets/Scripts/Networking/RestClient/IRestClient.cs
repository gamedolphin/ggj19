using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// An interface for a REST API client
/// </summary>
public interface IRestClient {
    IObservable<string> Get(string url, Dictionary<string, string> headers);
    IObservable<string> Post(string url, WWWForm form, Dictionary<string, string> headers);
    IObservable<string> Post(string url, WWWForm form);
}

/// <summary>
/// A wrapper of UniRx's ObservableWWW rest methods - implementing IRestClient
/// </summary>
public class UniRxRestClient : IRestClient {

    public IObservable<string> Get(string url, Dictionary<string, string> headers) {
        return ObservableWWW.Get(url, headers);
    }

    public IObservable<string> Post(string url, WWWForm form, Dictionary<string, string> headers) {
        return ObservableWWW.Post(url, form, headers);
    }

    public IObservable<string> Post(string url, WWWForm form) {
        return ObservableWWW.Post(url, form);
    }
}

public class RestClientSettings {
    public string ip;
}

public class RestClientManager {
    public string ip;

    public RestClientManager(RestClientSettings settings) {
        this.ip = settings.ip;
    }
}

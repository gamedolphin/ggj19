using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Client {

    [System.Serializable]
    public class ClientNetworkSettings {
        public string Ip;
        public int Port;
        public string Key;
    }

    public class ClientNetworkManager : IInitializable {

        public ClientNetworkManager(ClientNetworkSettings settings) {

        }

        public void Initialize() {

        }
    }
}

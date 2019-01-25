using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using LiteNetLib;
using System.Net;
using System.Net.Sockets;
using System;
using ZeroFormatter;

namespace Server  {

    [System.Serializable]
    public class ServerNetworkSettings {
        public int Port;
        public string Key;
    }

    public class ServerNetworkManager : IInitializable, ITickable, INetEventListener, IDisposable {

        private NetManager server;
        private string key;
        byte[] temp = new byte[1024];

        private List<NetPeer> clientList = new List<NetPeer>();
        private Dictionary<long, NetPeer> clientDic = new Dictionary<long,NetPeer>();

        public ServerNetworkManager(ServerNetworkSettings settings) {
            server = new NetManager(this);
            server.Start(settings.Port);
            server.UpdateTime = 15;
            key = settings.Key;
        }

        public void Dispose () {
            server.Stop();
        }

        public void Tick() {
            server.PollEvents();
        }

        public void Initialize() {

        }

        public void OnPeerConnected(NetPeer peer) {
            Debug.Log("[SERVER] We have new peer " + peer.EndPoint);

            clientList.Add(peer);
            clientDic.Add(peer.Id, peer);
        }

        public void OnNetworkError(IPEndPoint endPoint, SocketError socketErrorCode) {
            Debug.Log("[SERVER] error " + socketErrorCode);
        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader,
                                                UnconnectedMessageType messageType) {
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency) {
        }

        public void OnConnectionRequest(ConnectionRequest request) {
            request.AcceptIfKey(key);
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo) {
            Debug.Log("[SERVER] peer disconnected " + peer.EndPoint + ", info: " + disconnectInfo.Reason);

            clientList.RemoveAll(client => client.Id == peer.Id);
            clientDic.Remove(peer.Id);
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod) {


            var available = reader.AvailableBytes;
            reader.GetBytes(temp, available);
            var inputData = ZeroFormatterSerializer.Deserialize<InputData>(temp);

            reader.Recycle();
        }
    }
}

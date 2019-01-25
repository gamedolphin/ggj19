using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using LiteNetLib;
using System;
using System.Net;
using System.Net.Sockets;
using ZeroFormatter;

namespace Client {

    [System.Serializable]
    public class ClientNetworkSettings {
        public string Ip;
        public int Port;
        public string Key;
    }

    public class ClientNetworkManager : IInitializable, ITickable, INetEventListener, IDisposable  {

        private NetManager client;
        private NetPeer server;

        public ClientNetworkManager(ClientNetworkSettings settings) {
            client = new NetManager(this);
            client.Start();
            client.UpdateTime = 15;
            client.Connect(settings.Ip, settings.Port, settings.Key);
        }

        public void Dispose() {
            client.Stop();
            server = null;
        }

        public void Tick() {
            client.PollEvents();
        }

        public void Initialize() {

        }

        public void SendInput(InputData input) {
            if(server != null) {
                var bytes = ZeroFormatterSerializer.Serialize(input);
                server.Send(bytes, DeliveryMethod.ReliableOrdered);
            }
        }

        public void OnPeerConnected(NetPeer peer) {
            Debug.Log("[CLIENT] We connected to " + peer.EndPoint);
            server = peer;
        }

        public void OnNetworkError(IPEndPoint endPoint, SocketError socketErrorCode) {
            Debug.Log("[CLIENT] We received error " + socketErrorCode);
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod) {

        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType) {
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency) {

        }

        public void OnConnectionRequest(ConnectionRequest request) {

        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo) {
            Debug.Log("[CLIENT] We disconnected because " + disconnectInfo.Reason);
            server = null;
        }
    }
}

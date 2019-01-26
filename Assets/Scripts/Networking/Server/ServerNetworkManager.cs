using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using LiteNetLib;
using System.Net;
using System.Net.Sockets;
using System;
using ZeroFormatter;
using UnityEngine;

namespace Server  {

    [System.Serializable]
    public class ServerNetworkSettings {
        public int Port;
        public string Key;
    }

    public class ServerNetworkManager : IInitializable, ITickable, INetEventListener, IDisposable {

        private NetManager server;
        private string key;
        private byte[] temp = new byte[1024];
        private float updateTime = 0.2f;
        private float oldTime = 0;

        private List<NetPeer> clientList = new List<NetPeer>();

        private ServerSimulation serverSimulation;

        public ServerNetworkManager(ServerNetworkSettings settings, ServerSimulation sim) {
            serverSimulation = sim;
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

            if(Time.time - oldTime > updateTime) {
                oldTime = Time.time;
                UpdateAllClients();
            }
        }

        private void UpdateAllClients() {
            var worldState = serverSimulation.GetWorldState();
            var serialized = ZeroFormatterSerializer.Serialize(worldState);
            for (int i = 0; i < clientList.Count; ++i) {
                clientList[i].Send(serialized, DeliveryMethod.ReliableOrdered);
            }
        }

        public void Initialize() {

        }

        public void OnPeerConnected(NetPeer peer) {
            Debug.Log("[SERVER] We have new peer " + peer.EndPoint);

            clientList.Add(peer);
            serverSimulation.AddPlayer(peer.Id, peer);
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

            serverSimulation.RemovePlayer(peer.Id);
            clientList.RemoveAll(client => client.Id == peer.Id);
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod) {


            var available = reader.AvailableBytes;
            reader.GetBytes(temp, available);
            var inputData = ZeroFormatterSerializer.Deserialize<InputData>(temp);
            serverSimulation.AddInput(peer.Id, inputData);
            reader.Recycle();
        }
    }
}

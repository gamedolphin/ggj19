using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using Zenject;
using ZeroFormatter;
using System.Linq;

[ZeroFormattable]
public class WorldState {
    [Index(0)]
    public virtual IList<PlayerState> PlayerList { get; set; }
}

namespace Server {

    public class ServerSimulation  {

        public Dictionary<long, SimulationPlayer> playerDic = new Dictionary<long, SimulationPlayer>();
        public List<SimulationPlayer> playerList =  new List<SimulationPlayer>();

        private SimulationPlayer.Factory simFactory;

        public ServerSimulation(SimulationPlayer.Factory playerFactory) {
            simFactory = playerFactory;
        }

        public void AddPlayer(long id, NetPeer peer) {
            var player = simFactory.Create(peer.Id);
            playerDic.Add(id, player);
            playerList.Add(player);
        }

        public void RemovePlayer(long id) {
            GameObject.Destroy(playerDic[id]);
            playerDic.Remove(id);
            playerList.RemoveAll(p => p.Id == id);
        }

        public void AddInput(long id, InputData data) {
            playerDic[id].UpdateInput(data);
        }

        public WorldState GetWorldState () {
            var playerStates = playerList.Select(p => p.GetPlayerState());
            return new WorldState {
                PlayerList = playerStates.ToArray()
            };
        }
    }

}

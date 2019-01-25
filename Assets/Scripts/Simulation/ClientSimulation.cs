using UnityEngine;
using System.Collections.Generic;

namespace Client {

    public class ClientSimulation {

        private Dictionary<long,ClientSimulationPlayer> playerDic = new Dictionary<long, ClientSimulationPlayer>();

        private ClientSimulationPlayer.Factory simFactory;

        public ClientSimulation(ClientSimulationPlayer.Factory playerFactory) {
            simFactory = playerFactory;
        }

        public void AddWorldState(WorldState state) {
            var playerStates = state.PlayerList;

            for (int i=0; i < playerStates.Count; ++i) {
                var st = playerStates[i];

                if(playerDic.ContainsKey(st.Id)) {
                    playerDic[st.Id].UpdatePlayerState(st);
                }
                else {
                    var player = simFactory.Create(st.Id);
                    playerDic.Add(st.Id, player);
                }
            }
        }
    }
}

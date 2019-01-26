using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Client {

    public class ClientSimulation : ITickable {

        private Dictionary<int,ClientSimulationEntity> playerDic = new Dictionary<int, ClientSimulationEntity>();

        private ClientSimulationPlayer.Factory ownPlayerFactory;
        private ClientSimulationOtherPlayers.Factory otherPlayerFactory;

        private int ownId = -1;

        private Queue<WorldState> worldStates = new Queue<WorldState>();

        public ClientSimulation(ClientSimulationPlayer.Factory own,
                                ClientSimulationOtherPlayers.Factory other) {
            ownPlayerFactory = own;
            otherPlayerFactory = other;
        }

        public void SetOwnId(int hashcode) {
            ownId = hashcode;
        }

        public void AddWorldState(WorldState state) {
            worldStates.Enqueue(state);
        }

        public void Tick() {
            while(worldStates.Count > 0) {
                var state = worldStates.Dequeue();
                var playerStates = state.PlayerList;

                for (int i=0; i < playerStates.Count; ++i) {
                    var st = playerStates[i];

                    if(playerDic.ContainsKey(st.Hashcode)) {
                        playerDic[st.Hashcode].UpdateEntityState(st);
                    }
                    else {
                        if(st.Hashcode == ownId) {
                            var player = ownPlayerFactory.Create(st.Hashcode);                               player.UpdateEntityState(st);
                            playerDic.Add(st.Hashcode, player);
                        }
                        else {
                            var player = otherPlayerFactory.Create(st.Hashcode);
                            player.UpdateEntityState(st);
                            playerDic.Add(st.Hashcode, player);
                        }
                    }
                }

                ClearUpPlayers(playerStates);
            }
        }

        private void ClearUpPlayers(IList<PlayerState> states) {
            var keys = playerDic.Where(kvp => !states.Any(p => kvp.Key == p.Hashcode)).ToList();
            foreach(var kvp in keys)
            {
                GameObject.Destroy(kvp.Value.gameObject);
                playerDic.Remove(kvp.Key);
            }
        }
    }
}

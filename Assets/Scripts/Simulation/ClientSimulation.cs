using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Client {

    public class ClientSimulation : ITickable {

        private Dictionary<long,ClientSimulationEntity> playerDic = new Dictionary<long, ClientSimulationEntity>();

        private ClientSimulationPlayer.Factory ownPlayerFactory;
        private ClientSimulationOtherPlayers.Factory otherPlayerFactory;

        private long ownId = -1;

        private Queue<WorldState> worldStates = new Queue<WorldState>();

        public ClientSimulation(ClientSimulationPlayer.Factory own,
                                ClientSimulationOtherPlayers.Factory other) {
            ownPlayerFactory = own;
            otherPlayerFactory = other;
        }

        public void SetOwnId(long id) {
            ownId = id;
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

                    if(playerDic.ContainsKey(st.Id)) {
                        playerDic[st.Id].UpdateEntityState(st);
                    }
                    else {
                        if(st.Id == ownId) {
                            var player = ownPlayerFactory.Create(st.Id);
                            playerDic.Add(st.Id, player);
                        }
                        else {
                            var player = otherPlayerFactory.Create(st.Id);
                            playerDic.Add(st.Id, player);
                        }
                    }
                }

                ClearUpPlayers(playerStates);
            }
        }

        private void ClearUpPlayers(IList<PlayerState> states) {
            var keys = playerDic.Where(kvp => !states.Any(p => kvp.Key == p.Id)).ToList();
            foreach(var kvp in keys)
            {
                GameObject.Destroy(kvp.Value.gameObject);
                playerDic.Remove(kvp.Key);
            }
        }
    }
}

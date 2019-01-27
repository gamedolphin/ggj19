using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Client {

    public class ClientSimulation : ITickable {

        private Dictionary<int,ClientSimulationEntity> playerDic = new Dictionary<int, ClientSimulationEntity>();
        private Dictionary<int,QuestItemClient> questDic = new Dictionary<int, QuestItemClient>();

        private ClientSimulationPlayer.Factory ownPlayerFactory;
        private ClientSimulationOtherPlayers.Factory otherPlayerFactory;
        private QuestItemClient.Factory questFactory;
        private Dictionary<string,QuestItemClient> questPrefabs;

        private int ownId = -1;

        private Queue<WorldState> worldStates = new Queue<WorldState>();

        public ClientSimulation(ClientSimulationPlayer.Factory own,
                                ClientSimulationOtherPlayers.Factory other,
                                QuestItemClient.Factory qFactory,
                                Dictionary<string, QuestItemClient> qPrefabs) {
            ownPlayerFactory = own;
            otherPlayerFactory = other;
            questFactory = qFactory;
            questPrefabs = qPrefabs;
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

                var questStates = state.QuestList;
                for (int i= 0; i < questStates.Count; ++i) {
                    var questState = questStates[i];
                    if(questDic.ContainsKey(questState.Id)) {
                        questDic[questState.Id].UpdateEntityState(questState);
                    }
                    else {
                        var quest = questFactory.Create(questPrefabs[questState.QuestName]);
                        quest.UpdateEntityState(questState);
                        questDic.Add(questState.Id, quest);
                    }
                }

                ClearUpQuests(questStates);


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

        private void ClearUpQuests(IList<QuestInfo> states) {
            var keys = questDic.Where(kvp => !states.Any(p => kvp.Key == p.Id)).ToList();
            foreach(var kvp in keys)
            {
                GameObject.Destroy(kvp.Value.gameObject);
                questDic.Remove(kvp.Key);
            }
        }
    }
}

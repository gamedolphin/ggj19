using UnityEngine;
using Zenject;

public class ClientSimulationOtherPlayers : ClientSimulationEntity {
    public class Factory : PlaceholderFactory<int,ClientSimulationOtherPlayers> {}
}

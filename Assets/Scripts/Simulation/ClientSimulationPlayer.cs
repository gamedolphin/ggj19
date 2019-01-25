using UnityEngine;
using Zenject;

public class ClientSimulationPlayer : MonoBehaviour {
    public class Factory : PlaceholderFactory<long,ClientSimulationPlayer> {}

    public long Id;

    private float speed = 5;

    private Vector3 targetPos;

    [Inject]
    public void Construct(long id) {
        Id = id;
    }

    public void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime * speed);
    }

    public void UpdatePlayerState(PlayerState state) {
        var pos = state.Position;
        targetPos = new Vector3(pos.x, pos.y, pos.z);
    }
}

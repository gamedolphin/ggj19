using UnityEngine;
using Zenject;

public enum ClientEntityTypes {
    OWN_CHAR,
    OTHER_PLAYERS
}

[RequireComponent(typeof(Rigidbody))]
public class ClientSimulationEntity : MonoBehaviour {

    public long Id;
    public float speed = 5;

    public Vector3 targetPos;
    public Rigidbody rBody;

    [Inject]
    public void Construct(long id) {
        Id = id;
    }

    private void Awake() {
        rBody = GetComponent<Rigidbody>();
    }

    public virtual void FixedUpdate() {
        rBody.position = Vector3.Lerp(rBody.position, targetPos, Time.fixedDeltaTime * speed);
    }

    public virtual void UpdateEntityState(PlayerState state) {
        var pos = state.Position;
        targetPos = new Vector3(pos.x, pos.y, pos.z);
    }
}

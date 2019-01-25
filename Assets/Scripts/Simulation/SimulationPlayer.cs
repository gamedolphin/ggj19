using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZeroFormatter;

[ZeroFormattable]
public struct Vector3Sim
{
    [Index(0)]
    public float x;
    [Index(1)]
    public float y;
    [Index(2)]
    public float z;

    public Vector3Sim(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

[ZeroFormattable]
public struct PlayerState {
    [Index(0)]
    public long Id;
    [Index(1)]
    public Vector3Sim Position;

    public PlayerState(long id, Vector3Sim pos) {
        Id = id;
        Position = pos;
    }
}


[RequireComponent(typeof(Rigidbody))]
public class SimulationPlayer : MonoBehaviour {

    public class Factory : PlaceholderFactory<long,SimulationPlayer> {
    }

    private Rigidbody rBody;
    private InputData currentInput;

    private float speed = 5;

    public long Id;

    [Inject]
    public void Construct(long id) {
        Id = id;
    }

    public PlayerState GetPlayerState() {
        var pos = rBody.position;
        return new PlayerState(Id, new Vector3Sim(pos.x, pos.y, pos.z));
    }

    private void Awake() {
        rBody = GetComponent<Rigidbody>();
    }

    public void UpdateInput(InputData inputData) {
        currentInput = inputData;
    }

    private void FixedUpdate() {
        float x = currentInput.Left ? -1 : currentInput.Right ? 1 : 0;
        float y = currentInput.Up ? -1 : currentInput.Down ? 1 : 0;
        var direction = new Vector3(x,0,y);
        rBody.MovePosition(rBody.position + direction.normalized * speed * Time.fixedDeltaTime);
    }
}

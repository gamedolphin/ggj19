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
    public int Hashcode;
    [Index(1)]
    public Vector3Sim Position;
    [Index(2)]
    public long Index;
    [Index(3)]
    public string Name;
    [Index(4)]
    public int Health;

    public PlayerState(int hashcode, Vector3Sim pos, long index, string name, int health) {
        Hashcode = hashcode;
        Position = pos;
        Index = index;
        Name = name;
        Health = health;
    }

    public Vector3 GetPosition() {
        return new Vector3(Position.x, Position.y, Position.z);
    }
}

public interface IDamagable {
    void GetHit(int dmg);
}

[RequireComponent(typeof(Rigidbody))]
public class SimulationPlayer : MonoBehaviour, IDamagable {

    public class Factory : PlaceholderFactory<int, string,SimulationPlayer> {
    }

    private Rigidbody rBody;
    private InputData currentInput;

    private float speed = 5;

    public int Hashcode;
    public long Index;
    public string Name;
    public int Health = 100;
    public float Score = 0;

    private List<IInteractible> interactibles = new List<IInteractible>();

    [Inject]
    public void Construct(int hashcode, string name) {
        Hashcode = hashcode;
        Name = name;
        Score = PlayerPrefs.GetFloat("Score"+hashcode, 0);
    }

    public PlayerState GetPlayerState() {
        var pos = rBody.position;
        return new PlayerState(Hashcode, new Vector3Sim(pos.x, pos.y, pos.z), Index, Name, Health);
    }

    private void Awake() {
        rBody = GetComponent<Rigidbody>();
    }

    public void UpdateInput(InputData inputData) {
        currentInput = inputData;
        float x = currentInput.Left ? -1 : currentInput.Right ? 1 : 0;
        float y = currentInput.Up ? 1 : currentInput.Down ? -1 : 0;
        var direction = new Vector3(x,0,y);
        rBody.MovePosition(rBody.position + direction.normalized * speed * Time.fixedDeltaTime);
        Index = currentInput.Index;

        if(currentInput.Interact) {
            InteractWithItems();
        }
    }

    public void UpdateScore(int inc) {
        Score += inc;
        PlayerPrefs.SetFloat("Score"+Hashcode, Score);
    }

    public void GetHit(int damage) {
        if(Health > 0) {
            Health-= damage;
        }
        if(Health <= 0) {
            Die();
        }
    }

    public void Die() {
        Score = 0;
        PlayerPrefs.SetFloat("Score"+Hashcode, 0);
    }

    private void InteractWithItems() {
        interactibles.ForEach(item => item.Interact("Player", Hashcode));
    }

    public void OnTriggerEnter(Collider collider) {

        var interactible = collider.GetComponent<IInteractible>();

        if(interactible == null) return;

        interactibles.Add(interactible);

    }

    public void OnTriggerExit(Collider collider) {
        var interactible = collider.GetComponent<IInteractible>();

        if(interactible == null) return;

        if(interactibles.Contains(interactible)) {
            interactibles.Remove(interactible);
        }
    }
}

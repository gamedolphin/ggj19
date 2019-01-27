using UnityEngine;
using Zenject;
using Server;
using System.Collections.Generic;

public interface IInteractible {
    void Interact(string tag,int id);
}

[RequireComponent(typeof(BoxCollider))]
public class QuestItem : MonoBehaviour, IInteractible {

    public class Factory : PlaceholderFactory<UnityEngine.Object, QuestItem>
    {
    }

    public string QuestName;
    public float Health;
    public int Id;
    public int Points;

    [Inject] private ServerSimulation serverSim;
    [Inject] private QuestSpawner spawner;

    private List<int> playerIds = new List<int>();

    public QuestInfo GetQuestState() {
        return new QuestInfo(QuestName, new Vector3Sim(transform.position.x, transform.position.y, transform.position.z), Health, Id);
    }

    public void PlaceSelf (int id) {
        transform.position = new Vector3(Random.Range(10,140), 0, Random.Range(10,140));
        Id = id;
    }

    public void Interact(string tag, int id) {
        if(tag == "Player") {
            LoseHealth();
            if(!playerIds.Contains(id)) {
                playerIds.Add(id);
            }
        }
    }

    public void LoseHealth() {
        if(Health > 0) {
            Health -= 10;
        }
        if(Health <= 0) {
            Die();
        }
    }

    private void Die() {
        spawner.DespawnQuest(this);
        serverSim.DespawnQuest(this, playerIds);
        GameObject.Destroy(gameObject);
    }
}

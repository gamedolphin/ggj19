using UnityEngine;
using Zenject;
using Server;

[RequireComponent(typeof(BoxCollider))]
public class QuestItem : MonoBehaviour {

    public class Factory : PlaceholderFactory<UnityEngine.Object, QuestItem>
    {
    }

    public string QuestName;
    public float Health;
    public int Id;

    [Inject] private ServerSimulation serverSim;
    [Inject] private QuestSpawner spawner;

    public QuestInfo GetQuestState() {
        return new QuestInfo(QuestName, new Vector3Sim(transform.position.x, transform.position.y, transform.position.z), Health, Id);
    }

    public void PlaceSelf (int id) {
        transform.position = new Vector3(Random.Range(0,100), 0, Random.Range(0,100));
        Id = id;
    }

    public void LoseHealth() {
        Health -= 10;
        if(Health <= 0) {
            Die();
        }
    }

    private void Die() {
        spawner.DespawnQuest(this);
        serverSim.DespawnQuest(this);
        GameObject.Destroy(gameObject);
    }
}

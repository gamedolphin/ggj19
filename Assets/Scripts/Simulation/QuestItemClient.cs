using UnityEngine;
using Zenject;
using Server;

[RequireComponent(typeof(BoxCollider))]
public class QuestItemClient : MonoBehaviour {

    public class Factory : PlaceholderFactory<UnityEngine.Object, QuestItemClient>
    {
    }
    public string QuestName;
    public float Health;
    public int Id;

    public void UpdateEntityState (QuestInfo info) {
        QuestName = info.QuestName;
        Health = info.Health;
        Id = info.Id;
        transform.position = info.GetPosition();
    }
}

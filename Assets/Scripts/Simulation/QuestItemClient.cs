using UnityEngine;
using Zenject;
using Server;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class QuestItemClient : MonoBehaviour {

    public class Factory : PlaceholderFactory<UnityEngine.Object, QuestItemClient>
    {
    }
    public string QuestName;
    public float InitialHealth = -1;
    public float Health;
    public int Id;

    [SerializeField] private Slider slider;

    public void UpdateEntityState (QuestInfo info) {
        QuestName = info.QuestName;
        if(InitialHealth < 0) {
            InitialHealth = info.Health;
        }
        Health = info.Health;
        slider.value = (Health/InitialHealth)*100;
        Id = info.Id;
        transform.position = info.GetPosition();
    }
}

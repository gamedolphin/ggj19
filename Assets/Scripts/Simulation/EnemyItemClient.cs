using UnityEngine;
using Zenject;
using Server;

[RequireComponent(typeof(BoxCollider))]
public class EnemyItemClient : MonoBehaviour {

    public class Factory : PlaceholderFactory<UnityEngine.Object, EnemyItemClient>
    {
    }
    public string EnemyName;
    public int Id;
    private Vector3 target;

    public void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime);
    }

    public void UpdateEntityState (EnemyInfo info) {
        EnemyName = info.EnemyName;
        Id = info.Id;
        target = info.GetPosition();
    }
}

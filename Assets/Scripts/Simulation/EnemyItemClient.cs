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
    private Vector3 oldPosition;

    [SerializeField] private Transform playerModel;

    public void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime);
    }

    public void UpdateEntityState (EnemyInfo info) {
        EnemyName = info.EnemyName;
        Id = info.Id;
        target = info.GetPosition();
    }

    public void Update() {
        float step = 10 * Time.fixedDeltaTime;
        var dir = Vector3.RotateTowards(playerModel.forward, transform.position - oldPosition, step, 0.0f);
        playerModel.rotation = Quaternion.LookRotation(dir);

        oldPosition = transform.position;
    }
}

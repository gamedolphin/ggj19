using UnityEngine;
using Zenject;
using TMPro;

public class ClientSimulationOtherPlayers : ClientSimulationEntity {
    public class Factory : PlaceholderFactory<int,ClientSimulationOtherPlayers> {}

    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerModel;
    [SerializeField] private TextMeshPro name;

    public void Start() {
        animator.SetFloat("Speed", 0f);
    }

    public override void FixedUpdate() {
        float step = 10 * Time.fixedDeltaTime;
        var dir = Vector3.RotateTowards(playerModel.forward, targetPos - rBody.position, step, 0.0f);
        playerModel.rotation = Quaternion.LookRotation(dir);
        base.FixedUpdate();
    }

    public void Update() {
        Vector3 oldPosition = rBody.position;
        if(oldPosition != targetPos) {
            animator.SetFloat("Speed", 1f);
        } else {
            animator.SetFloat("Speed", 0f);
        }
    }
}

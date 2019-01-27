using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.UI;

public class ClientSimulationOtherPlayers : ClientSimulationEntity {
    public class Factory : PlaceholderFactory<int,ClientSimulationOtherPlayers> {}

    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerModel;
    [SerializeField] private TextMeshPro name;
    [SerializeField] private Slider slider;

    private Vector3 oldPosition;

    public void Start() {
        animator.SetFloat("Speed", 0f);
    }

    public override void UpdateEntityState(PlayerState state) {
        base.UpdateEntityState(state);
        name.text = state.Name;
        slider.value = state.Health;
    }

    public void Update() {
        if(oldPosition != rBody.position) {
            animator.SetFloat("Speed", 1f);
        } else {
            animator.SetFloat("Speed", 0f);
        }

        float step = 10 * Time.fixedDeltaTime;
        var dir = Vector3.RotateTowards(playerModel.forward, rBody.position - oldPosition, step, 0.0f);
        playerModel.rotation = Quaternion.LookRotation(dir);

        oldPosition = rBody.position;
    }
}

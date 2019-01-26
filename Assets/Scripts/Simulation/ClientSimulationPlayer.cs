using UnityEngine;
using Zenject;
using Client;
using UnityEngine.UI;
using TMPro;

public class ClientSimulationPlayer : ClientSimulationEntity {
    public class Factory : PlaceholderFactory<int,ClientSimulationPlayer> {}

    [Inject] private InputHandler inputHandler;

    [SerializeField] private float smoothing = 1;
    [SerializeField] private TextMeshPro name;

    private PlayerState[] states = new PlayerState[1024];
    private PlayerState latest;

    private void Start() {
        name.text = PlayerPrefs.GetString("userName");
    }

    public override void FixedUpdate() {
        var pos = targetPos;
        var serverIndex = latest.Index;
        var diff = inputHandler.index - serverIndex;

        for (int i=1; i <= diff; ++i) {
            var inputSlot = (serverIndex+i) % 1024;
            var currentInput = inputHandler.inputList[inputSlot];
            float x = currentInput.Left ? -1 : currentInput.Right ? 1 : 0;
            float y = currentInput.Up ? 1 : currentInput.Down ? -1 : 0;
            var direction = new Vector3(x,0,y);
            pos = (pos + direction.normalized * speed * Time.fixedDeltaTime);
            rBody.MovePosition(pos);
        }
        rBody.MovePosition(pos);
    }

    public override void UpdateEntityState(PlayerState state) {
        base.UpdateEntityState(state);
        long arrIndex = state.Index % 1024;
        states[arrIndex] = state;
        latest = state;
    }
}

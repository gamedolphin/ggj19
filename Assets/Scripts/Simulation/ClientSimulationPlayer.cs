using UnityEngine;
using Zenject;
using Client;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(BoxCollider))]
public class ClientSimulationPlayer : ClientSimulationEntity {
    public class Factory : PlaceholderFactory<int,ClientSimulationPlayer> {}

    [Inject] private InputHandler inputHandler;

    [SerializeField] private float smoothing = 1;
    [SerializeField] private TextMeshPro name;

    private RaycastHit m_Hit;
    private bool m_HitDetect;
    private float m_MaxDistance;
    private Collider m_Collider;


    private PlayerState[] states = new PlayerState[1024];
    private PlayerState latest;

    private void Start() {
        name.text = PlayerPrefs.GetString("userName");

         m_MaxDistance = 300.0f;
        m_Collider = GetComponent<BoxCollider>();
    }

    public override void FixedUpdate() {
        var pos = targetPos;
        var serverIndex = latest.Index;
        var diff = inputHandler.index - serverIndex;
        Vector3 direction = Vector3.zero;
        for (int i=1; i <= diff; ++i) {
            var inputSlot = (serverIndex+i) % 1024;
            var currentInput = inputHandler.inputList[inputSlot];
            float x = currentInput.Left ? -1 : currentInput.Right ? 1 : 0;
            float y = currentInput.Up ? 1 : currentInput.Down ? -1 : 0;
            direction = new Vector3(x,0,y);
            var mov = direction.normalized * speed * Time.fixedDeltaTime;
            // m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, direction, out m_Hit, transform.rotation, speed * Time.fixedDeltaTime);
            // if(!m_HitDetect) {

            // }
            pos = (pos + mov);
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

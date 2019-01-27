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
    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform model;
    [SerializeField] private Slider slider;

    private RaycastHit m_Hit;
    private bool m_HitDetect;
    private float m_MaxDistance;
    private Collider m_Collider;
    private bool m_started;


    private PlayerState[] states = new PlayerState[1024];
    private PlayerState latest;

    private void Start() {
        name.text = PlayerPrefs.GetString("userName");

         m_MaxDistance = 300.0f;
        m_Collider = GetComponent<BoxCollider>();
        m_started = true;
        animator.SetFloat("Speed", 0f);
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
            if(!Physics.CheckBox(pos + mov, transform.localScale/4, Quaternion.identity, collisionMask)) {
                pos = (pos + mov);
            }
        }
        if(pos != targetPos) {
            animator.SetFloat("Speed", 1f);
        } else {
            animator.SetFloat("Speed", 0f);
        }
        float step = 10*Time.fixedDeltaTime;
        var dir = Vector3.RotateTowards(model.forward, pos - rBody.position,step, 0.0f);
        model.rotation = Quaternion.LookRotation(dir);
        rBody.MovePosition(pos);
    }

    public override void UpdateEntityState(PlayerState state) {
        base.UpdateEntityState(state);
        long arrIndex = state.Index % 1024;
        states[arrIndex] = state;
        name.text = state.Name;
        latest = state;
        slider.value = state.Health;
    }
}

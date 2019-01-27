using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryPanel : MonoBehaviour {
    public GameObject parentPanel;
    public const int inventoryLength = 9;

    private BoolReactiveProperty IsInventoryOpen = new BoolReactiveProperty(false);
    private Image[] inventorySlots = new Image[inventoryLength];

    [Inject] private InventorySystem inventorySystem;

    private void Awake() {
        inventorySlots = parentPanel.GetComponentsInChildren<Image>();
    }

    // Start is called before the first frame update
    void Start() {
        parentPanel.SetActive(IsInventoryOpen.Value);

        IsInventoryOpen
            .SkipLatestValueOnSubscribe()
            .Where(open => open)
            .Subscribe(_ => InventoryOpened());

        IsInventoryOpen
            .SkipLatestValueOnSubscribe()
            .Where(open => !open)
            .Subscribe(_ => InventoryClosed());
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.I)) {
            IsInventoryOpen.Value = !IsInventoryOpen.Value;
            parentPanel.SetActive(IsInventoryOpen.Value);
        }
    }

    private void InventoryOpened() {
        for (int i = 0; i < inventorySystem.pickUpInventory.Count; i++) {
            inventorySlots[i].sprite = inventorySystem.pickUpInventory[i].sprite;
        }
    }

    private void InventoryClosed() {
        for (int i = 0; i < inventoryLength; i++) {
            inventorySlots[i].sprite = null;
        }
    }
}

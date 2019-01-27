using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventorySystem : IInitializable{

    public List<PickUpItems> pickUpInventory;

    public void Initialize() {
        throw new NotImplementedException();
    }

    public void GetInventory(string items) {
        pickUpInventory = JsonUtility.FromJson<List<PickUpItems>>(items);
    }
}

[Serializable]
public class PickUpItems {
    public int id;
    public string name;
    public Sprite sprite;
}

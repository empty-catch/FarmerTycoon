using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {
    [SerializeField]
    private string key;

    public string Key => key;

    [SerializeField]
    private ulong[] cost;

    public ulong[] Cost => cost;

    [SerializeField]
    private uint[] value;

    public uint[] Value => value;

    [SerializeField]
    private int itemLevel;

    public int ItemLevel => itemLevel;

    [SerializeField]
    private Sprite itemSprite;

    public Sprite ItemSprite => itemSprite;

    [SerializeField]
    private string itemName;

    public string ItemName => itemName;

    [SerializeField]
    private string itemDescription;

    public string ItemDescription => itemDescription;

    [SerializeField]
    private bool isUnlock;

    public bool IsUnlock {
        get => isUnlock;
        set => isUnlock = value;
    }

    [SerializeField]
    private bool isUse;

    public bool IsUse {
        get => isUse;
        set => isUse = value;
    }

    [SerializeField]
    private ItemType type;

    public ItemType Type => type;

    public void UseAsCloset() {
        UserData.Instance.SelectCloset = this;
        ClickerSystem.Instance.CostumeIncrement = Value[ItemLevel];
        FarmerHandler.Instance.UpdateItem();
    }

    public void UseAsTool() {
        UserData.Instance.SelectTool = this;
        ClickerSystem.Instance.ToolIncrement = Value[ItemLevel];
        FarmerHandler.Instance.UpdateItem();
    }

    public void UseAsPlant(int index) {
        UserData.Instance.SelectPlants[index] = this;
        ClickerSystem.Instance.PlantIncrement += Value[ItemLevel];
        var sprite = Resources.Load<Sprite>($"Planted/Planted{Key}");
        PlantHandler.Instance.AddItem(this, sprite, index);
        IsUnlock = false;
    }

    public void UseAsAnimal() {
        ClickerSystem.Instance.AnimalIncrement += Value[ItemLevel];
    }
}
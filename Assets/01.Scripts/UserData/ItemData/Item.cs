using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public int ItemLevel {
        get => itemLevel;
        set => itemLevel = value;
    }

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

    public void LevelUP() {
        itemLevel++;
        Debug.Log(UserData.Instance.SelectCloset.Key);

        switch (Type) {
            case ItemType.Closet when UserData.Instance.SelectCloset == this ||
                                      Key == "Farmer" && UserData.Instance.SelectCloset.Key == string.Empty:
                ClickerSystem.Instance.CostumeIncrement = Value[itemLevel];
                break;
            case ItemType.Animal when IsUnlock is true:
                ClickerSystem.Instance.AnimalIncrement += Value[itemLevel];
                ClickerSystem.Instance.AnimalIncrement -= Value[itemLevel - 1];
                break;
            case ItemType.Plant when UserData.Instance.SelectPlants.Contains(this):
                ClickerSystem.Instance.PlantIncrement += Value[itemLevel];
                ClickerSystem.Instance.PlantIncrement -= Value[itemLevel - 1];
                break;
            case ItemType.Tool when UserData.Instance.SelectTool == this:
                ClickerSystem.Instance.ToolIncrement = Value[ItemLevel];
                break;
        }
    }
}
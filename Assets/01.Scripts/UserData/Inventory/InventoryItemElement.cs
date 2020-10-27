using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemElement : MonoBehaviour {
    private Item itemData;

    private static Item tempClosetItem;

    public static Item TempClosetItem {
        get => tempClosetItem;
        set => tempClosetItem = value;
    }

    private static Item tempToolItem;

    public static Item TempToolItem {
        get => tempToolItem;
        set => tempClosetItem = value;
    }

    private static Item tempPlantItem;

    [SerializeField]
    private Image eyeCatch;

    public void Initialize(Item item) {
        itemData = item;
        eyeCatch.sprite = item.ItemSprite;
    }

    public void Select() {
        if (itemData.Type.Equals(ItemType.Closet)) {
            if (tempClosetItem != null && tempClosetItem.Equals(itemData)) {
                UserData.Instance.SelectCloset = itemData;
                ClickerSystem.Instance.CostumeIncrement = itemData.Value[itemData.ItemLevel];
            }
            else {
                tempClosetItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Tool)) {
            if (tempToolItem != null && tempToolItem.Equals(itemData)) {
                UserData.Instance.SelectTool = itemData;
            }
            else {
                tempToolItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Plant)) {
            if (tempPlantItem != null && tempPlantItem.Equals(itemData)) {
                if (!PlantHandler.Instance.AddPlant(itemData)) {
                    "Field full".Log();
                    return;
                }

                ClickerSystem.Instance.PlantIncrement += itemData.Value[itemData.ItemLevel];
                itemData.IsUnlock = false;
                Destroy(gameObject);
            }
            else {
                tempPlantItem = itemData;
            }
        }
    }
}
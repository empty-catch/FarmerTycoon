using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemElement : MonoBehaviour {
    private Item itemData;

    private static Item tempClosetItem;
    private static Item tempToolItem;
    private static Item tempPlantItem;
    private static Item tempAnimal;

    [SerializeField]
    private Image eyeCatch;

    public void Initialize(Item item) {
        itemData = item;
        eyeCatch.sprite = item.ItemSprite;
    }

    public void Select() {
        if (itemData.Type.Equals(ItemType.Closet)) {
            if (tempClosetItem != null && tempClosetItem.Equals(itemData)) {
                itemData.UseAsCloset();
                tempClosetItem = null;
            }
            else {
                tempClosetItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Tool)) {
            if (tempToolItem != null && tempToolItem.Equals(itemData)) {
                itemData.UseAsTool();
                tempToolItem = null;
            }
            else {
                tempToolItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Plant)) {
            if (tempPlantItem != null && tempPlantItem.Equals(itemData)) {
                if (PlantHandler.Instance.IsFull) {
                    "Field full".Log();
                    return;
                }

                UIManager.Instance.OpenUI<PlantSelectUI>();
                UIManager.Instance.OpenUI<MainUI>();
                UIManager.Instance.CloseUI<InventoryHUD>();

                ((PlantSelectUI)PlantSelectUI.Instance).Selected += index => {
                    itemData.UseAsPlant(index);
                    tempPlantItem = null;
                    UIManager.Instance.CloseUI<PlantSelectUI>();
                };
            }
            else {
                tempPlantItem = itemData;
            }
        }
    }
}
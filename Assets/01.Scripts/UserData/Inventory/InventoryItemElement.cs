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
                UserData.Instance.SelectCloset = itemData;
                ClickerSystem.Instance.CostumeIncrement = itemData.Value[itemData.ItemLevel];
                FarmerHandler.Instance.UpdateItem();
                tempClosetItem = null;
            }
            else {
                tempClosetItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Tool)) {
            if (tempToolItem != null && tempToolItem.Equals(itemData)) {
                UserData.Instance.SelectTool = itemData;
                ClickerSystem.Instance.ToolIncrement = itemData.Value[itemData.ItemLevel];
                FarmerHandler.Instance.UpdateItem();
                tempToolItem = null;
            }
            else {
                tempToolItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Plant)) {
            if (tempPlantItem != null && tempPlantItem.Equals(itemData)) {
                var sprite = Resources.Load<Sprite>($"Planted/Planted{itemData.Key}");
                if (!PlantHandler.Instance.AddItem(itemData, sprite)) {
                    "Field full".Log();
                    return;
                }

                ClickerSystem.Instance.PlantIncrement += itemData.Value[itemData.ItemLevel];
                itemData.IsUnlock = false;
                tempPlantItem = null;
                Destroy(gameObject);
            }
            else {
                tempPlantItem = itemData;
            }
        }
        else if (itemData.Type.Equals(ItemType.Animal)) {
            if (tempAnimal != null && tempAnimal.Equals(itemData)) {
                /*
                 * 하셔야 하는 작업 있으시면 하시면 댐다
                 */
                itemData.IsUnlock = false;
                tempAnimal = null;
                Destroy(gameObject);
            }
            else {
                tempAnimal = itemData;
            }
        }
    }
}
using System;
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

    [SerializeField]
    private Image background;

    private static InventoryItemElement currentSelect;
    public static InventoryItemElement CurrentSelect {
        get => currentSelect;
        set => currentSelect = value;
    }
    
    public void Initialize(Item item) {
        itemData = item;
        eyeCatch.sprite = item.ItemSprite;
    }

    public void Select() {
        if (itemData.Type.Equals(ItemType.Closet)) {
            if (tempClosetItem != null && tempClosetItem.Equals(itemData)) {
                itemData.UseAsCloset();
                tempClosetItem = null;
                CurrentSelect?.SetColor(Color.white);
                CurrentSelect = null;
            }
            else {
                tempClosetItem = itemData;
                CurrentSelect?.SetColor(Color.white);
                CurrentSelect = this;
                CurrentSelect.SetColor(Color.yellow);
            }
        }
        else if (itemData.Type.Equals(ItemType.Tool)) {
            if (tempToolItem != null && tempToolItem.Equals(itemData)) {
                itemData.UseAsTool();
                tempToolItem = null;
                CurrentSelect?.SetColor(Color.white);
                CurrentSelect = null;
            }
            else {
                tempToolItem = itemData;
                CurrentSelect?.SetColor(Color.white);
                CurrentSelect = this;
                CurrentSelect.SetColor(Color.yellow);
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

                SingletonObject<PlantSelectUI>.Instance.Selected += index => {
                    itemData.UseAsPlant(index);
                    tempPlantItem = null;
                    UIManager.Instance.CloseUI<PlantSelectUI>();
                };
                
                CurrentSelect?.SetColor(Color.white);
                CurrentSelect = null;
            }
            else {
                tempPlantItem = itemData;
                CurrentSelect?.SetColor(Color.white);
                CurrentSelect = this;
                CurrentSelect.SetColor(Color.yellow);
            }
        }
    }

    public void SetColor(Color color) {
        background.color = color;
    }
}
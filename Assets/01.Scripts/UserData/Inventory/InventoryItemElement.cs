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
                return;
            }
            tempClosetItem = itemData;
        }
        else if (itemData.Type.Equals(ItemType.Tool)) {
            if (tempToolItem != null && tempToolItem.Equals(itemData)) {
                UserData.Instance.SelectTool = itemData;
                return;
            }
            tempToolItem = itemData;
        }
        else {
            UserData.Instance.CurrentSelectItem = itemData;
        }
    }
}
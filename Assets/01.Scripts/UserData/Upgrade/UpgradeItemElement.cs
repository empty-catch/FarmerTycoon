using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeItemElement : MonoBehaviour {
    private Item information;

    [SerializeField]
    private Image eyeCatch;

    [SerializeField]
    private Text name;

    [SerializeField]
    private Text cost;

    [SerializeField]
    private Button buttonCommand;
    
    private UIBase parent;
    
    public void Initialize(UIBase parent, Item itemData) {
        this.parent = parent;
        information = itemData;
        eyeCatch.sprite = itemData.ItemSprite;
        name.text = itemData.ItemName;
    }

    public void BuyItem() {
        ClickerSystem.Instance.Coin -= information.Cost[information.ItemLevel];
        var newParent = parent as UpgradeHUD;
        
        ItemData.Instance.TryGetItem(information.Key).IsUnlock = true;
        newParent.RefreshList();

        if (information.Type == ItemType.Animal &&
            AnimalHandler.Instance.AddItem(information, information.ItemSprite)) {
            ClickerSystem.Instance.AnimalIncrement += information.Value[information.ItemLevel];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine.UI;
using UnityEngine;

public class ItemUIElement : MonoBehaviour {
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
        cost.text = $"{itemData.Cost[itemData.ItemLevel].ToKorean().ToString()} 원";
    }

    public void BuyItem() {    
        if (UserData.Instance.Coin < information.Cost[information.ItemLevel]) {
            "Not enough coin.".Log();
            return;
        }

        var newParent = parent as StoreHUD;
        information.Key.Log();
        ItemData.Instance.TryGetItem(information.Key).IsUnlock = true;
        newParent.RefreshList();

    }
}

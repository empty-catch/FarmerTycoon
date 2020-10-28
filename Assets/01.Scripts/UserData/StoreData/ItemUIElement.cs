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

        if (ItemData.Instance.TryGetItem(information.Key).IsUnlock) {
            "Already have item.".Log();
            return;
        }

        ClickerSystem.Instance.Coin -= information.Cost[information.ItemLevel];
        var newParent = parent as StoreHUD;
        
        ItemData.Instance.TryGetItem(information.Key).IsUnlock = true;
        newParent.RefreshList();

        if (information.Type == ItemType.Animal &&
            AnimalHandler.Instance.AddItem(information, information.ItemSprite)) {
            information.UseAsAnimal();
        }
    }
}
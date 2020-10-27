using System.Collections;
using System.Collections.Generic;
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

    public void Initialize(Item itemData) {
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
        ItemData.Instance.TryGetItem(information.Key).IsUnlock = true;

        if (information.Type == ItemType.Animal &&
            AnimalHandler.Instance.AddItem(information, information.ItemSprite)) {
            ClickerSystem.Instance.AnimalIncrement += information.Value[information.ItemLevel];
        }
    }
}
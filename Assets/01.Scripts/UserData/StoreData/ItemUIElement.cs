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
        cost.text = itemData.Cost.ToKorean().ToString();
    }

    public void BuyItem() {
        if (UserData.Instance.Coin < information.Cost) {
            return;
        }

        ItemData.Instance.TryGetItem(information.Key).IsUnlock = true;
    }
}

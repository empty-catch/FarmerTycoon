using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreHUD : UIBase {
    [SerializeField]
    private GameObject elementParent;
    
    [SerializeField]
    private GameObject itemElement;
    
    private List<ItemUIElement> items = new List<ItemUIElement>();

    private void Awake() {
        CreateItems();
        gameObject.transform.SetParent(MainCanvas.Instance.gameObject.transform);
    }
    
    public override void OpenUI(params object[] args) {
        if (args.Length > 0) {
            throw new ArgumentException("Too many argument count.");
        }

        gameObject.SetActive(true);
    }

    private void CreateItems() {
        var objectInterval = itemElement.GetComponent<RectTransform>().sizeDelta.y;
        
        for (int i = 0; i < ItemData.Instance.Items.Count; i++) {
            var newItem = Instantiate(itemElement, elementParent.transform).GetComponentSafe<ItemUIElement>();
            newItem.Initialize(ItemData.Instance.Items[i]);
            
            newItem.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, -i * objectInterval);
            
            items.Add(newItem);
        }
    }
    
    public override void CloseUI(params object[] args) {
        if (args.Length > 0) {
            throw new ArgumentException("Too many argument count.");
        }
        
        gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;
using UnityEngine.UI;

public class StoreHUD : UIBase {
    [SerializeField]
    private GameObject pivot;
    
    [SerializeField]
    private GameObject[] elementParents;
    
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

        var contextHolder = gameObject.GetComponentSafe<ContextHolder>();
        contextHolder.Context = new StoreHUDContext();
        
        gameObject.SetActive(true);
    }

    public void RefreshList() {
        for (int i = 0; i < items.Count; i++) {
            Destroy(items[i].gameObject);
        }
        items.Clear();
        CreateItems();
    }
    
    private void CreateItems() {
        ItemData itemData = ItemData.Instance;
        for (int i = 0; i < itemData.Items.Count; i++) {
            if (itemData.Items[i].IsUnlock) {
                continue;
            }
            
            var elementParent = itemData.Items[i].Type switch {
                ItemType.Closet => elementParents[0],
                ItemType.Animal => elementParents[1],
                ItemType.Plant => elementParents[2],
                ItemType.Tool => elementParents[3],
            };
            
            var newItem = Instantiate(itemElement, elementParent.transform).GetComponentSafe<ItemUIElement>();
            newItem.Initialize(this, itemData.Items[i]);
            
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

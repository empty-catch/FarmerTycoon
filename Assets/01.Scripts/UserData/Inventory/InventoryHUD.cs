using System;
using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;

public class InventoryHUD : UIBase {
    [SerializeField]
    private GameObject pivot;

    [SerializeField]
    private GameObject[] elementParents;

    [SerializeField]
    private GameObject itemElement;

    [SerializeField]
    private GameObject sortObject;
    
    private List<InventoryItemElement> items = new List<InventoryItemElement>();
    
    public override void OpenUI(params object[] args) {
        if (args.Length > 0) {
            throw new ArgumentException("Too many argument count.");
        }

        var contextHolder = gameObject.GetComponent<ContextHolder>();
        contextHolder.Context = new InventoryHUDContext();
        
        CreateItems();
    }
    
    private void CreateItems() {
        var objectInterval = itemElement.GetComponent<RectTransform>().sizeDelta.y;
        var sortObjectInterval = sortObject.GetComponent<RectTransform>().sizeDelta.y;
        GameObject sortParentObject = null;
        
        ItemData itemData = ItemData.Instance;
        for (int i = 0; i < itemData.Items.Count; i++) {
            if (itemData.Items[i].IsUnlock == false) {
                 continue;
            }
            
            var elementParent = itemData.Items[i].Type switch {
                ItemType.Closet => elementParents[0],
                ItemType.Animal => elementParents[1],
                ItemType.Plant => elementParents[2],
                ItemType.Tool => elementParents[3],
            };
            
            if (i % 5 == 0) {
                var objectPosition = new Vector2();
                objectPosition.y = ((i % 5) * sortObjectInterval);
                sortParentObject = Instantiate(sortObject, elementParent.transform);
                sortParentObject.GetComponent<RectTransform>().localPosition = objectPosition;
            }

            var newItem = Instantiate(itemElement, sortParentObject.transform).GetComponentSafe<InventoryItemElement>();
            newItem.Initialize(itemData.Items[i]);
            
            var childCount = elementParent.transform.childCount;
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

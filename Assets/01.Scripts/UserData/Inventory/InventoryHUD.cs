using System;
using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Presentation;
using Slash.Unity.DataBind.Core.Utils;
using UnityEngine;

public class InventoryHUD : UIBase {
    [SerializeField]
    private GameObject pivot;

    [SerializeField]
    private GameObject[] elementParents;

    [SerializeField]
    private GameObject itemElement;

    private List<InventoryItemElement> items = new List<InventoryItemElement>();

    private void Awake() {
        gameObject.transform.SetParent(MainCanvas.Instance.gameObject.transform);
    }

    public override void OpenUI(params object[] args) {
        if (args.Length > 0) {
            throw new ArgumentException("Too many argument count.");
        }

        var contextHolder = gameObject.GetComponent<ContextHolder>();
        contextHolder.Context = new InventoryHUDContext();
        gameObject.SetActive(true);
        CreateItems();
    }

    private void CreateItems() {
        var objectInterval = itemElement.GetComponent<RectTransform>().sizeDelta.y;

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

            var newItem = Instantiate(itemElement, elementParent.transform).GetComponentSafe<InventoryItemElement>();
            newItem.Initialize(itemData.Items[i]);

            var childCount = elementParent.transform.childCount;
            items.Add(newItem);
        }
    }

    public override void CloseUI(params object[] args) {
        if (args.Length > 0) {
            throw new ArgumentException("Too many argument count.");
        }

        foreach (var parent in elementParents) {
            parent.DestroyChildren();
        }

        gameObject.SetActive(false);
    }
}
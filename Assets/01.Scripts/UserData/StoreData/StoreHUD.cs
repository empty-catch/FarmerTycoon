using System;
using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Presentation;
using Slash.Unity.DataBind.Core.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

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

    private void CreateItems() {
        var objectInterval = itemElement.GetComponent<RectTransform>().sizeDelta.y;

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
            newItem.Initialize(itemData.Items[i]);

            var childCount = elementParent.transform.childCount;

            newItem.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0,
                pivot.transform.localPosition.y + (-childCount * objectInterval));

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
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEditor;

public class ItemData : ScriptableObject {
    private static ItemData instance;

    public static ItemData Instance {
        get {
            if (instance is null) {
                var itemData = Resources.Load<ItemData>("GameData/ItemData");
                if (itemData is null) {
                    var path = "Assets/Resources/GameData";

                    var prefabsFolder = new DirectoryInfo(path);
                    if (prefabsFolder.Exists == false) {
                        prefabsFolder.Create();
                    }

                    itemData = ScriptableObject.CreateInstance<ItemData>();
                    AssetDatabase.CreateAsset(itemData, $"{path}/ItemData.asset");
                }

                instance = itemData;
            }

            return instance;
        }
    }

    [SerializeField]
    private List<Item> items = new List<Item>();

    public List<Item> Items => items;

    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    private void OnEnable() {
        ResetObject();
        foreach (var item in items) {
            if (itemDictionary.ContainsKey(item.Key) == false) {
                itemDictionary.Add(item.Key, item);
            }
        }
    }

    public Item TryGetItem(string key) {
        if (itemDictionary.ContainsKey(key) == false) {
            throw new ArgumentException("Not found Item key.");
        }

        return itemDictionary[key];
    }

    public void SubscribeItem(Item item) {
        if (items.Contains(item) == false) {
            items.Add(item);
            itemDictionary.Add(item.Key, item);
        }
    }

    [Button("Reset Object")]
    public void ResetObject() {
        for (int i = 0; i < items.Count; i++) {
            items[i].ItemLevel = 0;
            if (items[i].Key.Equals("Farmer")) {
                items[i].IsUnlock = true;
                items[i].IsUse = true;
                continue;
            }

            items[i].IsUnlock = false;
            items[i].IsUse = false;
        }
    }
}
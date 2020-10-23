using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {
    [SerializeField]
    private string key;
    public string Key => key;
    
    [SerializeField]
    private ulong[] cost;
    public ulong[] Cost => cost;

    [SerializeField]
    private int itemLevel;
    public int ItemLevel => itemLevel;
    
    [SerializeField]
    private Sprite itemSprite;
    public Sprite ItemSprite => itemSprite;
    
    [SerializeField]
    private string itemName;
    public string ItemName => itemName;
    
    [SerializeField]
    private string itemDescription;
    public string ItemDescription => itemDescription;

    [SerializeField]
    private bool isUnlock;
    public bool IsUnlock {
        get => isUnlock;
        set => isUnlock = value;
    }

    [SerializeField]
    private bool isUse;
    public bool IsUse {
        get => isUse;
        set => isUse = value;
    }
    
    [SerializeField]
    private ItemType type;
    public ItemType Type => type;
}
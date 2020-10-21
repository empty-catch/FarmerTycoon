using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField]
    private string key;
    public string Key => key;
    
    [SerializeField]
    private int cost;
    public int Cost => cost;

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
    
    public virtual void Buy() { }
    public virtual void Use() { }
}
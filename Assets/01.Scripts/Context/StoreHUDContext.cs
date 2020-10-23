using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

public class StoreHUDContext : Context {
    private ItemType currentTap;
    
    public StoreHUDContext() {
        currentTap = ItemType.Closet;
    }

    public void ChangeTap(int index) {
        currentTap = (ItemType)index;
    }
    
    public void CloseStore() {
        UIManager.Instance.CloseUI<StoreHUD>();
    }
}
using System;
using Slash.Unity.DataBind.Core.Data;

public class MainContext : Context {
    public event Action IncreasingCoin;

    public void IncreaseCoin() {
        IncreasingCoin?.Invoke();
    }

    public void OpenStore() {
        UIManager.Instance.OpenUI<StoreHUD>();
        UIManager.Instance.CloseUI<MainUI>();
    }

    public void OpenInventory() {
        UIManager.Instance.OpenUI<InventoryHUD>();
        UIManager.Instance.CloseUI<MainUI>();
    }
}
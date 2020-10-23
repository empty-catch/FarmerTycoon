using System;
using Slash.Unity.DataBind.Core.Data;

public class MainContext : Context {
    public event Action IncreasingCoin;
    
    public void IncreaseCoin() {
        IncreasingCoin?.Invoke();
    }
}
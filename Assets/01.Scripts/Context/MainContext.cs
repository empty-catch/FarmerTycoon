using System;
using Slash.Unity.DataBind.Core.Data;

public class MainContext : Context {
    public event Action IncreasingCoin;

    private readonly Property<ulong> coinProperty = new Property<ulong>();
    private readonly Property<uint> autoIncrementProperty = new Property<uint>();
    private readonly Property<uint> touchIncrementProperty = new Property<uint>();

    public ulong Coin {
        get => coinProperty.Value;
        set => coinProperty.Value = value;
    }

    public uint AutoIncrement {
        get => autoIncrementProperty.Value;
        set => autoIncrementProperty.Value = value;
    }

    public uint TouchIncrement {
        get => touchIncrementProperty.Value;
        set => touchIncrementProperty.Value = value;
    }

    public void IncreaseCoin() {
        IncreasingCoin?.Invoke();
    }
}
using DG.Tweening;
using UnityEngine;

public class ClickerSystem : SingletonObject<ClickerSystem> {
    private const uint DefaultTouchIncrement = 1;

    private uint costumeIncrement = 10;
    private uint toolIncrement;
    private uint animalIncrement;
    private uint plantIncrement = 1;

    private Tweener coinTweener;

    public uint CostumeIncrement {
        get => costumeIncrement;
        set {
            costumeIncrement = value;
            CoinContext.AutoIncrement = AutoIncrement;
        }
    }

    public uint ToolIncrement {
        get => toolIncrement;
        set {
            toolIncrement = value;
            CoinContext.TouchIncrement = TouchIncrement;
        }
    }

    public uint AnimalIncrement {
        get => animalIncrement;
        set {
            animalIncrement = value;
            CoinContext.AutoIncrement = AutoIncrement;
        }
    }

    public uint PlantIncrement {
        get => plantIncrement;
        set {
            plantIncrement = value;
            CoinContext.TouchIncrement = TouchIncrement;
        }
    }

    private uint AutoIncrement => costumeIncrement + animalIncrement;
    private uint TouchIncrement => DefaultTouchIncrement + toolIncrement + plantIncrement;
    private StartContext StartContext => MasterContext.Instance.StartContext;
    private CoinContext CoinContext => MasterContext.Instance.CoinContext;
    private MainContext MainContext => MasterContext.Instance.MainContext;

    public ulong Coin {
        get => UserData.Instance.Coin;
        set {
            UserData.Instance.Coin = value;
            coinTweener.ChangeValues(Coin, Coin + AutoIncrement);
            coinTweener.Restart();
        }
    }

    private void Awake() {
        StartContext.StartedGame += StartIncreasing;
        MainContext.IncreasingCoin += () => Coin += TouchIncrement;
        CoinContext.AutoIncrement = AutoIncrement;
        CoinContext.TouchIncrement = TouchIncrement;
    }

    private void StartIncreasing() {
        coinTweener = DOTween.To(() => Coin, value => UserData.Instance.Coin = value, Coin + AutoIncrement, 1f)
                             .OnUpdate(() => CoinContext.Coin = Coin).SetEase(Ease.Linear)
                             .SetLoops(-1, LoopType.Incremental);
    }
}
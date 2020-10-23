using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerSystem : MonoBehaviour {
    [SerializeField]
    private uint autoIncrement;

    [SerializeField]
    private uint touchIncrement;

    private Tweener coinTweener;

    private static StartContext StartContext => MasterContext.Instance.StartContext;
    private static MainContext MainContext => MasterContext.Instance.MainContext;

    private static ulong Coin {
        get => UserData.Instance.Coin;
        set => UserData.Instance.Coin = value;
    }

    private void Awake() {
        StartContext.StartedGame += StartIncreasing;
        MainContext.IncreasingCoin += IncreaseCoin;
        MainContext.AutoIncrement = autoIncrement;
        MainContext.TouchIncrement = touchIncrement;
    }

    private void StartIncreasing() {
        coinTweener = DOTween.To(() => Coin, value => Coin = value, Coin + autoIncrement, 1f)
                             .OnUpdate(() => MainContext.Coin = Coin).SetEase(Ease.Linear)
                             .SetLoops(-1, LoopType.Incremental);
    }

    private void IncreaseCoin() {
        Coin += touchIncrement;
        coinTweener.ChangeValues(Coin, Coin + touchIncrement);
        coinTweener.Restart();
    }
}
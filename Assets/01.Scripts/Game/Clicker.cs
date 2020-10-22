using DG.Tweening;
using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour {
    [SerializeField]
    private ContextHolder contextHolder;

    [SerializeField]
    private uint autoIncrement;

    [SerializeField]
    private uint touchIncrement;

    private MainContext context;
    private Tweener coinTweener;

    private static ulong Coin {
        get => UserData.Instance.Coin;
        set => UserData.Instance.Coin = value;
    }

    public void IncreaseCoin() {
        Coin += touchIncrement;
        coinTweener.ChangeValues(Coin, Coin + autoIncrement);
        coinTweener.Restart();
    }

    private void Awake() {
        context = new MainContext {
            AutoIncrement = autoIncrement,
            TouchIncrement = touchIncrement
        };
        contextHolder.Context = context;

        coinTweener = DOTween.To(() => Coin, value => Coin = value, Coin + autoIncrement, 1f)
                             .OnUpdate(() => context.Coin = Coin).SetEase(Ease.Linear)
                             .SetLoops(-1, LoopType.Incremental);
    }
}
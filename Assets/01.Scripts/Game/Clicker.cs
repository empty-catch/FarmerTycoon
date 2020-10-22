using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour {
    [SerializeField]
    private uint autoIncrement;

    [SerializeField]
    private uint touchIncrement;

    [SerializeField]
    private Text coinText;

    [SerializeField]
    private Text autoIncrementText;

    [SerializeField]
    private Text touchIncrementText;

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
        autoIncrementText.text = $"{autoIncrement.ToKorean()}원/자동";
        touchIncrementText.text = $"{touchIncrement.ToKorean()}원/터치";
        
        coinTweener = DOTween.To(() => Coin, value => Coin = value, Coin + autoIncrement, 1f)
                             .OnUpdate(() => coinText.text = $"{Coin.ToKorean()}원").SetEase(Ease.Linear)
                             .SetLoops(-1, LoopType.Incremental);
    }
}
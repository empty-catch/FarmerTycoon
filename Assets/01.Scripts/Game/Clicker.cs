using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour {
    [SerializeField]
    private uint increment;

    [SerializeField]
    private uint autoIncrement;

    [SerializeField]
    private Text coinText;

    private Tweener coinTweener;

    private static uint Coin {
        get => UserData.Instance.Coin;
        set => UserData.Instance.Coin = value;
    }

    public void IncreaseCoin() {
        Coin += increment;
        coinText.text = Coin.ToString();
        coinTweener.ChangeValues(Coin, Coin + autoIncrement);
        coinTweener.Restart();
    }

    private void Awake() {
        coinTweener = DOTween.To(() => Coin, value => Coin = value, Coin + autoIncrement, 1f)
                             .OnUpdate(() => coinText.text = Coin.ToString()).SetEase(Ease.Linear)
                             .SetLoops(-1, LoopType.Incremental);
    }
}
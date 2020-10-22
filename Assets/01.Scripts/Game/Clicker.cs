using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour {
    [SerializeField]
    private int increment;

    [SerializeField]
    private int autoIncrement;

    [SerializeField]
    private Text coinText;

    private int coin;
    private Tweener coinTweener;

    public void IncreaseCoin() {
        coin += increment;
        coinText.text = coin.ToString();
        coinTweener.ChangeValues(coin, coin + autoIncrement);
        coinTweener.Restart();
    }

    private void Awake() {
        coinTweener = DOTween.To(() => coin, value => coin = value, coin + autoIncrement, 1f)
                             .OnUpdate(() => coinText.text = coin.ToString()).SetEase(Ease.Linear)
                             .SetLoops(-1, LoopType.Incremental);
    }
}
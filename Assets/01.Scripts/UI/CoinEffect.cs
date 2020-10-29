using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinEffect : MonoBehaviour {
    [SerializeField]
    private float duration = 0.5f;

    [SerializeField]
    private float startY;

    [SerializeField]
    private RectTransform[] images;

    private Queue<RectTransform> imageQueue;

    private void Play() {
        if (imageQueue.Count == 0) {
            throw new Exception("Not enough image usable");
        }

        var image = imageQueue.Dequeue();
        image.gameObject.SetActive(true);
        image.anchoredPosition = new Vector2(Random.Range(-540f, 0f), startY);
        image.localScale = Vector3.one;

        image.DOScale(0f, duration).SetEase(Ease.InExpo);
        image.DOAnchorPos(Vector2.zero, duration)
             .OnComplete(() => {
                 image.gameObject.SetActive(false);
                 imageQueue.Enqueue(image);
             });
    }

    private void Awake() {
        imageQueue = new Queue<RectTransform>(images);
        MasterContext.Instance.MainContext.IncreasingCoin += Play;
    }
}
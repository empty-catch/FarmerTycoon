using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : SingletonObject<MainCanvas> {
    private Canvas canvas;

    private void Awake() {
        canvas = gameObject.GetComponent<Canvas>();
    }
}
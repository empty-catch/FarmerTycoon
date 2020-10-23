using System;
using UnityEngine;

public class StartUI : UIBase {
    public override void CloseUI(params object[] args) {
        gameObject.SetActive(false);
    }

    private void Awake() {
        transform.position = Vector3.zero;
    }
}
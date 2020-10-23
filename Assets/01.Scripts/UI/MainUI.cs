using System;
using UnityEngine;

public class MainUI : UIBase {
    public override void OpenUI(params object[] args) {
        gameObject.SetActive(true);
    }

    public override void CloseUI(params object[] args) {
        gameObject.SetActive(false);
    }

    private void Awake() {
        transform.position = Vector3.zero;
        CloseUI();
    }
}
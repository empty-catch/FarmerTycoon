using System;
using UnityEngine;

public class PlantSelectUI : UIBase {
    private Action<int> selected;

    public event Action<int> Selected {
        add => selected = value;
        remove => throw new NotImplementedException();
    }

    public override void OpenUI(params object[] args) {
        gameObject.SetActive(true);
    }

    public override void CloseUI(params object[] args) {
        gameObject.SetActive(false);
    }

    public void Select(int index) {
        selected?.Invoke(index);
        transform.GetChild(0).GetChild(index).gameObject.SetActive(false);
    }

    private void Awake() {
        transform.position = Vector3.zero;
        CloseUI();
    }
}
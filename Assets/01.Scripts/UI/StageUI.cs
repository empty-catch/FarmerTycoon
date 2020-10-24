using System;
using UnityEngine;

public class StageUI : UIBase {
    [SerializeField]
    private StageData[] datas;

    private static StageContext StageContext => MasterContext.Instance.StageContext;

    public override void OpenUI(params object[] args) {
        gameObject.SetActive(true);
    }

    public override void CloseUI(params object[] args) {
        gameObject.SetActive(false);
    }

    private void Awake() {
        StageContext.Logo = datas[0].logo;
        foreach (var data in datas) {
            var context = new StageButtonContext(data.title, data.cost);
            StageContext.StageButtonContexts.Add(context);

            context.StageChanged += () => {
                StageContext.Logo = data.logo;
                StageContext.ResetButtonsColor();
                context.Color = new Color32(237, 225, 86, 255);
            };
        }

        StageContext.ResetButtonsColor();
        transform.position = Vector3.zero;
        CloseUI();
    }

    [Serializable]
    private class StageData {
        public string title;
        public ulong cost;
        public Sprite logo;
    }
}
using System;
using System.Linq;
using Slash.Unity.DataBind.Core.Data;
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
            StageContext.StageButtonContexts.Add(new StageButtonContext(data.title, data.cost));
        }

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
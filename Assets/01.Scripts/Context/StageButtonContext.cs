using System;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

public class StageButtonContext : Context {
    public event Action StageChanged;
    
    private readonly Property<string> stageNameProperty = new Property<string>();
    private readonly Property<ulong> costProperty = new Property<ulong>();
    private readonly Property<Sprite> logoProperty = new Property<Sprite>();

    public string StageName {
        get => stageNameProperty.Value;
        private set => stageNameProperty.Value = value;
    }

    public ulong Cost {
        get => costProperty.Value;
        private set => costProperty.Value = value;
    }

    public StageButtonContext(string stageName, ulong cost) {
        StageName = stageName;
        Cost = cost;
    }

    public void ChangeStage() {
        StageChanged?.Invoke();
    }
}
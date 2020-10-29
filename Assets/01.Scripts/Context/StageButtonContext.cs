using System;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

public class StageButtonContext : Context {
    public event Action StageChanged;

    private readonly Property<string> stageNameProperty = new Property<string>();
    private readonly Property<ulong> costProperty = new Property<ulong>();
    private readonly Property<Color> colorProperty = new Property<Color>();
    private bool hasUnlocked = false;

    public string StageName {
        get => stageNameProperty.Value;
        private set => stageNameProperty.Value = value;
    }

    public ulong Cost {
        get => costProperty.Value;
        private set => costProperty.Value = value;
    }

    public Color Color {
        get => colorProperty.Value;
        set => colorProperty.Value = value;
    }

    public StageButtonContext(string stageName, ulong cost) {
        StageName = stageName;
        Cost = cost;
    }

    public void ChangeStage() {
        if (hasUnlocked) {
            StageChanged?.Invoke();
        }
        else if (ClickerSystem.Instance.Coin >= Cost) {
            hasUnlocked = true;
            ClickerSystem.Instance.Coin -= Cost;
            StageChanged?.Invoke();
        }
    }
}
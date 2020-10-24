using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

public class StageContext : Context {
    private readonly Property<Collection<StageButtonContext>> stageButtonContestsProperty =
        new Property<Collection<StageButtonContext>>(new Collection<StageButtonContext>());

    private readonly Property<Sprite> logoProperty = new Property<Sprite>();

    public Collection<StageButtonContext> StageButtonContexts {
        get => stageButtonContestsProperty.Value;
        private set => stageButtonContestsProperty.Value = value;
    }

    public Sprite Logo {
        get => logoProperty.Value;
        set => logoProperty.Value = value;
    }

    public void Open() {
        UIManager.Instance.OpenUI<StageUI>();
        UIManager.Instance.CloseUI<MainUI>();
    }

    public void Close() {
        UIManager.Instance.OpenUI<MainUI>();
        UIManager.Instance.CloseUI<StageUI>();
    }

    public void ResetButtonsColor() {
        foreach (var context in StageButtonContexts) {
            context.Color = new Color32(224, 241, 194, 255);
        }
    }
}
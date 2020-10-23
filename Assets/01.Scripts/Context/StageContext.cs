using Slash.Unity.DataBind.Core.Data;

public class StageContext : Context {
    private readonly Property<Collection<StageButtonContext>> stageButtonContestsProperty =
        new Property<Collection<StageButtonContext>>(new Collection<StageButtonContext>());

    public Collection<StageButtonContext> StageButtonContexts {
        get => stageButtonContestsProperty.Value;
        private set => stageButtonContestsProperty.Value = value;
    }

    public StageContext() {
        StageButtonContexts.Add(new StageButtonContext("경상도", 0));
        StageButtonContexts.Add(new StageButtonContext("강원도", 1_200_000_000));
        StageButtonContexts.Add(new StageButtonContext("경기도", 2_400_000_000));
        StageButtonContexts.Add(new StageButtonContext("제주도", 4_800_000_000));
        StageButtonContexts.Add(new StageButtonContext("서울", 8_000_000_000));
    }

    public void Open() {
        UIManager.Instance.OpenUI<StageUI>();
        UIManager.Instance.CloseUI<MainUI>();
    }

    public void Close() {
        UIManager.Instance.OpenUI<MainUI>();
        UIManager.Instance.CloseUI<StageUI>();
    }
}
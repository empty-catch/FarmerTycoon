using Slash.Unity.DataBind.Core.Data;

public class StageButtonContext : Context {
    private readonly Property<string> stageNameProperty = new Property<string>();
    private readonly Property<ulong> costProperty = new Property<ulong>();

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
}
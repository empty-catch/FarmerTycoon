using Slash.Unity.DataBind.Core.Data;
using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;

public class MasterContext : Context {
    private readonly Property<StartContext> startContextProperty = new Property<StartContext>();
    private readonly Property<CoinContext> coinContextProperty = new Property<CoinContext>();
    private readonly Property<MainContext> mainContextProperty = new Property<MainContext>();
    private readonly Property<StageContext> stageContextProperty = new Property<StageContext>();
    
    private static MasterContext instance;

    private MasterContext() {
        StartContext = new StartContext();
        CoinContext = new CoinContext();
        MainContext = new MainContext();
        StageContext = new StageContext();
    }

    public static MasterContext Instance {
        get {
            if (instance != null) {
                return instance;
            }

            var contextHolder = Object.FindObjectOfType<ContextHolder>();
            instance = new MasterContext();
            contextHolder.Context = instance;
            return instance;
        }
    }

    public StartContext StartContext {
        get => startContextProperty.Value;
        private set => startContextProperty.Value = value;
    }

    public CoinContext CoinContext {
        get => coinContextProperty.Value;
        private set => coinContextProperty.Value = value;
    }

    public MainContext MainContext {
        get => mainContextProperty.Value;
        private set => mainContextProperty.Value = value;
    }

    public StageContext StageContext {
        get => stageContextProperty.Value;
        private set => stageContextProperty.Value = value;
    }
}
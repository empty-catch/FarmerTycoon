using Slash.Unity.DataBind.Core.Data;
using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;

public class MasterContext : Context {
    private readonly Property<StartContext> startContextProperty = new Property<StartContext>();
    private readonly Property<MainContext> mainContextProperty = new Property<MainContext>();
    private static MasterContext instance;

    private MasterContext() {
        StartContext = new StartContext();
        MainContext = new MainContext();
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

    public MainContext MainContext {
        get => mainContextProperty.Value;
        private set => mainContextProperty.Value = value;
    }
}
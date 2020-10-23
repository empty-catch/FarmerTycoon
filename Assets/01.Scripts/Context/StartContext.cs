using System;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

public class StartContext : Context {
    public event Action StartedGame;
    
    public void StartGame() {
        UIManager.Instance.CloseUI<StartUI>();
        UIManager.Instance.OpenUI<MainUI>();
        StartedGame?.Invoke();
    }

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
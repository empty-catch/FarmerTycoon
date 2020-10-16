using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UIManager : SingletonObject<UIManager> {
    public void OpenUI<T>(params object[] args) where T : UIBase {
        SingletonObject<T>.Instance.OpenUI(args);
    }

    public void CloseUI<T>(params object[] args) where T : UIBase {
        SingletonObject<T>.Instance.CloseUI(args);   
    }
}

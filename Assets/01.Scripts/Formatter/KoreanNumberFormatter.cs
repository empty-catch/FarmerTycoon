﻿using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;

public class KoreanNumberFormatter : DataProvider {
    [SerializeField]
    private bool isSimple;

    [SerializeField]
    private string prefix;

    [SerializeField]
    private DataBinding argument;

    public override object Value =>
        $"{(isSimple ? argument.GetValue<ulong>().ToSimpleKorean() : argument.GetValue<ulong>().ToKorean())}{prefix}";

    public override void Init() {
        AddBinding(argument);
    }

    protected override void UpdateValue() {
        OnValueChanged();
    }
}
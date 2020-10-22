using Slash.Unity.DataBind.Core.Presentation;
using UnityEngine;

public class KoreanNumberFormatter : DataProvider {
    [SerializeField]
    private string prefix;

    [SerializeField]
    private DataBinding argument;

    public override object Value => $"{argument.GetValue<ulong>().ToKorean()}{prefix}";

    protected new void Awake() {
        AddBinding(argument);
    }

    protected override void UpdateValue() {
        OnValueChanged(Value);
    }
}
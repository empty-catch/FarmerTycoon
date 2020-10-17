using UnityEngine;
using UnityEngine.Events;

public class Clicker : MonoBehaviour {
    [SerializeField]
    private int increase;

    [SerializeField]
    private UnityEvent<string> onClicked;

    private int coin;

    public void IncreaseCoin() {
        coin += increase;
        onClicked?.Invoke(coin.ToString());
    }
}
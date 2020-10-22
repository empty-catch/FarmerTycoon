using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour {
    [SerializeField]
    private int increment;

    [SerializeField]
    private int autoIncrement;

    [SerializeField]
    private Text coinText;

    private int coin;

    public void IncreaseCoin() {
        coin += increment;
        coinText.text = coin.ToString();
    }
}
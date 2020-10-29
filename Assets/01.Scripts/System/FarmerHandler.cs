using System;
using UnityEngine;
using UnityEngine.UI;

public class FarmerHandler : SingletonObject<FarmerHandler> {
    [SerializeField]
    private Image image;

    public void UpdateItem() {
        var tool = UserData.Instance.SelectTool;
        var costume = UserData.Instance.SelectCloset;
        Debug.Log(costume.Key);
        var trimmedCostume = costume.Key == string.Empty
            ? "Farmer"
            : costume.ItemSprite.name.Replace("Costume", string.Empty);

        var path = tool.Key == string.Empty
            ? $"Costumes/Costume{trimmedCostume}"
            : $"CharactersWithTools/{trimmedCostume}/{trimmedCostume}{tool.ItemSprite.name}";

        var sprite = Resources.Load<Sprite>(path);
        image.sprite = sprite;
    }
}
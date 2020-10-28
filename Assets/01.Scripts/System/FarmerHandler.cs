using UnityEngine;
using UnityEngine.UI;

public class FarmerHandler : SingletonObject<FarmerHandler> {
    [SerializeField]
    private Image image;

    public void UpdateItem() {
        var tool = UserData.Instance.SelectTool;
        var costume = UserData.Instance.SelectCloset;
        var trimmedCostume =  costume.ItemSprite.name.Replace("Costume", string.Empty);

        var path = tool is null
            ? $"Costumes/{costume.ItemSprite.name}"
            : $"CharactersWithTools/{trimmedCostume}/{trimmedCostume}{tool.ItemSprite.name}";

        var sprite = Resources.Load<Sprite>(path);
        image.sprite = sprite;
    }
}
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlantHandler : SingletonObject<PlantHandler> {
    [SerializeField]
    private Image[] plantImages;

    public bool AddPlant(Item item) {
        var plantImage = plantImages.FirstOrDefault(image => !image.gameObject.activeSelf);
        if (plantImage == null) {
            return false;
        }

        var sprite = Resources.Load<Sprite>($"Planted/Planted{item.Key}");
        plantImage.sprite = sprite;
        plantImage.gameObject.SetActive(true);
        return true;
    }
}
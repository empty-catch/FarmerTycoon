using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHandler : SingletonObject<AnimalHandler> {
    [SerializeField]
    private Image[] images;

    public bool AddItem(Item item, Sprite sprite) {
        var itemImage = images.FirstOrDefault(image => !image.gameObject.activeSelf);
        if (itemImage == null) {
            return false;
        }

        itemImage.sprite = sprite;
        itemImage.gameObject.SetActive(true);
        return true;
    }
}
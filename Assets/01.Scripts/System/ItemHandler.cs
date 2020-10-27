using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : SingletonObject<ItemHandler> {
    [SerializeField]
    protected Image[] images;

    public virtual bool AddItem(Item item, Sprite sprite) {
        var plantImage = images.FirstOrDefault(image => !image.gameObject.activeSelf);
        if (plantImage == null) {
            return false;
        }

        plantImage.sprite = sprite;
        plantImage.gameObject.SetActive(true);
        return true;
    }
}
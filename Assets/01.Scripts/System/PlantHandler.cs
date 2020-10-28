using UnityEngine;
using UnityEngine.UI;

public class PlantHandler : SingletonObject<PlantHandler> {
    [SerializeField]
    private Image[] images;

    private int count;

    public bool IsFull => count >= 6;

    public void AddItem(Item item, Sprite sprite, int index) {
        count++;
        images[index].sprite = sprite;
        images[index].gameObject.SetActive(true);
    }
}
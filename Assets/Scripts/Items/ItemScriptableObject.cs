using UnityEngine;

public enum ItemType { Default, Pony, Food, Gold}
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] public ItemType itemType;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] string itemName;
    [SerializeField] float maxAmount; //максимальное кол-во этого объекта в слоте
    [SerializeField] public Sprite icon;
}

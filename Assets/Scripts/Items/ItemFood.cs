using UnityEngine;

[CreateAssetMenu(fileName = "Item Food", menuName = "Inventory/Items/ New Food")]
public class ItemFood : ItemScriptableObject
{
    //что-то отличительное у еды
    void Start()
    {
        itemType = ItemType.Food;
    }
}

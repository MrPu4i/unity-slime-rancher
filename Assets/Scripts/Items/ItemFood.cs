using UnityEngine;

[CreateAssetMenu(fileName = "Item Food", menuName = "Inventory/Items/ New Food")]
public class ItemFood : ItemScriptableObject
{
    //���-�� ������������� � ���
    void Start()
    {
        itemType = ItemType.Food;
    }
}

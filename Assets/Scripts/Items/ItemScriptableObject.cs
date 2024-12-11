using UnityEngine;

public enum ItemType { Default, Pony, Food, Gold}
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/ New Item")]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] public ItemType itemType;
    [SerializeField] string itemName;
    [SerializeField] public float maxAmount; //������������ ���-�� ����� ������� � �����
    [SerializeField] public Sprite icon;
    [SerializeField] public GameObject itemPrefab;
}

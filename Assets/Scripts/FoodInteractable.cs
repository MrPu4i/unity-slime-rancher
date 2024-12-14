using UnityEngine;

public class FoodInteractable : InteractableObject
{
    [SerializeField] ItemScriptableObject item;
    [SerializeField] float amount;
    public InventoryManager inventoryManager;

    public override void Interact()
    {
        //��� ������, ����� �������� ���
        inventoryManager.AddItem(item, amount);
        Destroy(gameObject);
        //� ������� ������ :0
    }
}

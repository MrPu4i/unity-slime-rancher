using UnityEngine;

public class InteractableFood : InteractableObject
{
    [SerializeField] ItemScriptableObject item;
    [SerializeField] float amount;
    public InventoryManager inventoryManager;

    public override void Interact()
    {
        //��� ������, ����� �������� ���
        inventoryManager.AddItem(item, amount);
        //� ������� ������ :0
    }
}

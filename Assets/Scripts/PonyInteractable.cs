using UnityEngine;

public class PonyInteractable : InteractableObject
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

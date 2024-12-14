using UnityEngine;

public class FoodInteractable : InteractableObject
{
    [SerializeField] ItemScriptableObject item;
    [SerializeField] float amount;
    public InventoryManager inventoryManager;

    public override void Interact()
    {
        //что делаем, когда нажимаем ЛКМ
        inventoryManager.AddItem(item, amount);
        Destroy(gameObject);
        //и удаляем объект :0
    }
}

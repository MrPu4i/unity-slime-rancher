using UnityEngine;

public class InteractableFood : InteractableObject
{
    [SerializeField] ItemScriptableObject item;
    [SerializeField] float amount;
    public InventoryManager inventoryManager;

    public override void Interact()
    {
        //что делаем, когда нажимаем ЛКМ
        inventoryManager.AddItem(item, amount);
        //и удаляем объект :0
    }
}

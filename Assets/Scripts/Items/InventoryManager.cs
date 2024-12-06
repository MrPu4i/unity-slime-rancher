using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //получаение всех слотов в список(у меня 4 слота... крейзи
    [SerializeField] Transform quickInventory;
    [SerializeField] List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        Debug.Log(quickInventory.childCount);
        for (int i = 0; i < quickInventory.childCount; i++)
        {
            if (quickInventory.GetChild(i).GetComponent<InventorySlot>() != null) //проверяем точно ли у слота есть скрипт InventorySlot
            {
                
                slots.Add(quickInventory.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    public void AddItem(ItemScriptableObject _item, float _amount)
    {
        Debug.Log(slots.Count);
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true) //ещё нет объекта
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.text_amount.text = _amount.ToString();
                return;
            }
            if (slot.item == _item) //когда уже есть объект в инвентаре, и он тот же самый
            {
                slot.amount += _amount;
                slot.text_amount.text = slot.amount.ToString();
                return;
            }
        }
    }
}

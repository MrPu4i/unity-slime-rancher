using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //���������� ���� ������ � ������(� ���� 4 �����... ������
    [SerializeField] Transform quickInventory;
    [SerializeField] public List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        for (int i = 0; i < quickInventory.childCount; i++)
        {
            if (quickInventory.GetChild(i).GetComponent<InventorySlot>() != null) //��������� ����� �� � ����� ���� ������ InventorySlot
            {
                
                slots.Add(quickInventory.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    public void AddItem(ItemScriptableObject _item, float _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item) //����� ��� ���� ������ � ���������, � �� ��� �� �����
            {
                if (slot.amount + _amount <= _item.maxAmount)
                {
                    slot.amount += _amount;
                    slot.text_amount.text = slot.amount.ToString();
                    return;
                }
            }
            if (slot.isEmpty == true) //��� ��� �������
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.text_amount.text = _amount.ToString();
                return;
            }
        }
    }
}

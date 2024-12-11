using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class QuickslotInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    [SerializeField] Transform quickslotParent;
    [SerializeField] InventoryManager inventoryManager;
    int currentQuickslotID = 0; //номер слота, который у нас выбран
    [SerializeField] Sprite selectedSprite;
    [SerializeField] Sprite notSelectedSprite;

    Controls controls;

    private void Start()
    {
        controls = new Controls(); //считываение пользовательского ввода
        controls.Player.Enable();
        controls.Player.Interact.performed += DropItem_performed; //здесь мы засовываем тот метод, который происходим по ЛКМ
    }
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw < 0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // Прибавляем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:
            //значит здесь мы вызываем метод, в который суём номер ячейки, и в зависимости от номера ячейки соответствующий предмет
            //из слота можем выкинуть

        }
        if (mw > -0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                // Уменьшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:
        }
    }
    //// Используем цифры
        //for (int i = 0; i < quickslotParent.childCount; i++)
        //{
        //    // если мы нажимаем на клавиши 1 по 5 то...
        //    if (Input.GetKeyDown((i + 1).ToString()))
        //    {
        //        // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
        //        if (currentQuickslotID == i)
        //        {
        //            // Ставим картинку "selected" на слот если он "not selected" или наоборот
        //            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
        //            {
        //                quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
        //            }
        //            else
        //            {
        //                quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
        //            }
        //        }
        //        // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
        //        else
        //        {
        //            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
        //            currentQuickslotID = i;
        //            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
        //        }
        //    }
        //}

    private void DropItem_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //этот метод происходит тогда, когда мы нажимаем ЛКМ, и объект, который выбран в слоте у нас (item)
        //выбрасывается
        print($"Ура по левой кнопке что-то происходит, наш предмет в слоте: {inventoryManager.slots[currentQuickslotID].item}");
        DropItem(); //метод выбрасывания
    }
    private void DropItem()
    {
        //получить предмет из слота - inventoryManager.slots[currentQuickslotID].item
        if (inventoryManager.slots[currentQuickslotID].item != null) //если в слота выбранном что-то есть, тогда делаем метод на ЛКМ
        {
            //надо перед игроком заспавнить префаб предмета, который выкидываем
            //обнулить всё в слоте
        }
    }
}

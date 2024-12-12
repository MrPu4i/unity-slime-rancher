using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] float throwForce = 10f; // Сила броска
    [SerializeField] float throwUpwardForce = 5f; // Добавляет немного подъема

    InventorySlot cur_slot = null;
    Controls controls;
    bool canPickUp;

    private void Start()
    {
        controls = new Controls(); //считываение пользовательского ввода
        controls.Player.Enable();
        controls.Player.Drop.performed += DropItem_performed; //здесь мы засовываем тот метод, который происходим по ЛКМ
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
        //print($"Ура по левой кнопке что-то происходит, наш предмет в слоте: {inventoryManager.slots[currentQuickslotID].item}"); //работает, он видит предмет
        DropItem(); //метод выбрасывания
    }
    private void DropItem()
    {
        cur_slot = inventoryManager.slots[currentQuickslotID];
        //print("Зашёл в DropItem");
        //получить предмет из слота - inventoryManager.slots[currentQuickslotID].item
        if (cur_slot.item != null) //если в слота выбранном что-то есть, тогда делаем метод на ЛКМ
        {
            //Мне здесь нужен метод Drop
            //но если я ещё буду реализовывать появление предметов в руке
            //тогда надо к Drop там иметь доступ
            //ПОЛУЧАЕТСЯ это будет в этом классе, и будет меняться предмет в зависимости от того
            //Какой сейчас в руке. Эта информация - cur_slot

            Drop(); //просто хотим выкинуть предмет один
        }
    }
    void Drop() //выбрасываем текущий объект
    {
        cur_slot.amount -= 1;
        /*cur_slot.item.itemPrefab.transform.parent = null;
        cur_slot.item.itemPrefab.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        cur_slot.item.itemPrefab = null;*/
        GameObject prefabForSpawn = cur_slot.item.itemPrefab;
        if (cur_slot.amount == 0) //значит у нас только 1 предмет
        {
            cur_slot.item.itemPrefab = null;
            cur_slot.SetIcon(null, 0); //убираем иконку
            cur_slot.isEmpty = true; //ячейка пустая
            cur_slot.text_amount.text = "";
        }
        else
        {
            cur_slot.text_amount.text = cur_slot.amount.ToString(); //убираем текст
        }
        
        //надо ещё, чтобы перед игроком появлялся префаб
        //print("Сейчас перед игроком должен появитсья префаб яблока выброшенного");

        SpawnPrefab(prefabForSpawn);
    }
    void SpawnPrefab(GameObject _prefabForSpawn)
    {
        GameObject newObject = Instantiate(_prefabForSpawn, new Vector3(35, 30,-18), Quaternion.identity);
        InteractableFood food = newObject.GetComponent<InteractableFood>();
        if (food != null)
        {
            food.inventoryManager = inventoryManager;
        }
        else
        {
            Debug.LogError("MyNewObject Script not found on prefab");
        }
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Объект не имеет компонента Rigidbody!");
            Destroy(newObject);
            return;
        }
        rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)); // 10 - глубина. Можно подстроить под свой проект
        //Vector3 throwDirection = (worldPos - transform.position).normalized;
        // throwDirection.y += throwUpwardForce;

        // Добавляем силу в направлении броска.
        //rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        newObject.transform.parent = null;
    }
    void SetItemInHand() //этот метод тогда, когда нажимаем Е
    {
        if (canPickUp) Drop(); //Просто проверяет, если уже что-то есть, то выбрасываем


        //вот это всё для того, что бы поставить предмет в руку
        cur_slot.item.itemPrefab.GetComponent<Rigidbody>().isKinematic = true;
        cur_slot.item.itemPrefab.transform.parent = transform;
        cur_slot.item.itemPrefab.transform.localPosition = Vector3.zero;
        cur_slot.item.itemPrefab.transform.localEulerAngles = new Vector3(10f, 2f, 0f);
        canPickUp = true;
    }

}

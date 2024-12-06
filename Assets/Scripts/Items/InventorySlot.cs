using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //слот инвентаря
    [SerializeField] public ItemScriptableObject item; //какой объект в слоте
    [SerializeField] public float amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public TextMeshProUGUI text_amount;

    private void Start()
    {
        //узнаём в начале iconGO и text_amount
        iconGO = transform.GetChild(0).gameObject; //получаем из первого чайлда изображение
        text_amount = transform.GetChild(1).GetComponent<TextMeshProUGUI>(); //получаем из второго чайлда текст количества 
    }
    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1); //выносим из прозрачности
        iconGO.GetComponent<Image>().sprite = icon; //вставляем иконку
    }
}

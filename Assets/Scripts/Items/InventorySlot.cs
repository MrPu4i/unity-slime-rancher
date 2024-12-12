using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //���� ���������
    [SerializeField] public ItemScriptableObject item; //����� ������ � �����, ����� ��� �������
    [SerializeField] public float amount; //������� ������ �������� � ���������
    public bool isEmpty = true;
    public GameObject iconGO;
    public TextMeshProUGUI text_amount;

    

    private void Start()
    {
        //����� � ������ iconGO � text_amount
        iconGO = transform.GetChild(0).gameObject; //�������� �� ������� ������ �����������
        text_amount = transform.GetChild(1).GetComponent<TextMeshProUGUI>(); //�������� �� ������� ������ ����� ���������� 
    }
    public void SetIcon(Sprite icon, int col)
    {
        iconGO.GetComponent<Image>().color = new Color(col, col, col, col); //������� �� ������������
        iconGO.GetComponent<Image>().sprite = icon; //��������� ������
    }
    
}

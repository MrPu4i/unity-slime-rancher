using UnityEngine;

public class InteractableButton : InteractableObject
{
    [SerializeField] private GameObject sh_button;
    [SerializeField] private GameManager gameM;
    [SerializeField] GameObject[] shelter_walls;
    Material material;
    public float Cost { get; set; } = 100f;
    private bool wallsActive = false;
    void Start()
    {
        material = sh_button.GetComponent<Renderer>().material;
    }

    public override void Interact()
    {
        //��������� ���� ������ ������.
        if (wallsActive == false) //��� ������
        {
            if (gameM.Money >= Cost)
            {
                gameM.Money -= Cost;
                foreach (GameObject wall in shelter_walls)
                {
                    wall.gameObject.SetActive(true);
                }
                wallsActive = true;
            }
        }
        else
        {
            return; //���� ������ ��� ����, ������ �� ������
            //����� � ������� ������� ��������� �� 300, ������� ����� ������ ������ ����,
            //�� ���� ����� ������ �������, � ���������� :)
        }
        //material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}

using UnityEngine;

public class InteractableButton : InteractableObject
{
    [SerializeField] private GameObject sh_button;
    [SerializeField] private GameManager gameM;
    [SerializeField] GameObject[] shelter_walls;
    [SerializeField] public float whatBut;
    public float Cost { get; set; } = 100f;
    public bool wallsActive = false;

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
                gameObject.tag = "Untagged";
                //����� � ������� ������� ��������� �� 300, ������� ����� ������ ������ ����,
                //�� ���� ����� ������ �������, � ���������� :)
                wallsActive = true;
            }
        }
    }
}

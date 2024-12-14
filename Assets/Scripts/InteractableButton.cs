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
        //всплывает меню выбора стенок.
        if (wallsActive == false) //нет стенок
        {
            if (gameM.Money >= Cost)
            {
                gameM.Money -= Cost;
                foreach (GameObject wall in shelter_walls)
                {
                    wall.gameObject.SetActive(true);
                }
                gameObject.tag = "Untagged";
                //можно в будущем сделать улучшение за 300, которое будет делать стенки выше,
                //тк пони могут иногда прыгать, и перелетать :)
                wallsActive = true;
            }
        }
    }
}

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
                wallsActive = true;
            }
        }
        else
        {
            return; //если стенки уже есть, ничего не делаем
            //можно в будущем сделать улучшение за 300, которое будет делать стенки выше,
            //тк пони могут иногда прыгать, и перелетать :)
        }
        //material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}

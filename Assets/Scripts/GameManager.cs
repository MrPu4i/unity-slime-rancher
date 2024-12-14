using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] shelter_walls;
    [SerializeField] TextMeshProUGUI text_money;
    [SerializeField] TextMeshProUGUI text_wall_cost;
    [SerializeField] InteractableButton inter_button;

    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] GameObject musicImage;
    [SerializeField] Sprite icon_on;
    [SerializeField] Sprite icon_off;

    public float Money { get; set; }
    void Start()
    {
        Console.WriteLine("лол");
        TurnOffWallsOnStart();
        WallCost();
        Money = 250;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I) && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.M))
        {
            if (backgroundMusic.enabled == false)
            {
                backgroundMusic.enabled = true; //включаю
                musicImage.GetComponent<Image>().sprite = icon_on;
            }
            else
            {
                backgroundMusic.enabled = false;
                musicImage.GetComponent<Image>().sprite = icon_off;
            }
        }
        HowMuchMoney();
    }
    private void TurnOffWallsOnStart()
    {
        foreach (GameObject wall in shelter_walls)
        {
            wall.gameObject.SetActive(false);
        }
    }
    private void HowMuchMoney()
    {
        text_money.text = $"{Money}";
    }
    public void WallCost()
    {
        text_wall_cost.text = $"Стоимость стены: {inter_button.Cost}";
    }
}

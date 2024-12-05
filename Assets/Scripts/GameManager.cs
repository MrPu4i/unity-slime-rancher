using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] shelter_walls;
    [SerializeField] TextMeshProUGUI text_money;
    [SerializeField] TextMeshProUGUI text_wall_cost;
    [SerializeField] InteractableButton inter_button;

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
        Console.Write(inter_button.Cost);
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

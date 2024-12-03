using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] shelter_walls;
    [SerializeField] TextMeshProUGUI text_money;

    private float money;
    void Start()
    {
        TurnOffWallsOnStart();
        money = 100;
    }

    void Update()
    {
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
        text_money.text = $"{money}";
    }
}

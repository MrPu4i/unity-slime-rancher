using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //������� ��� � ����
    [SerializeField] private GameManager gameManager;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject ponyPrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject burgerPrefab;

    private void Start()
    {
        StartCoroutine(WaitSpawnPony());
        StartCoroutine(WaitSpawnApple());
    }
    public void SpawnPony()
    {
        //���� ���������� ����� � �����
        Vector3 vectorForSpawn = new Vector3(Random.Range(-36, -48), 1, 2);
        GameObject newObject = Instantiate(ponyPrefab, vectorForSpawn, Quaternion.identity);
        PonyInteractable ponyIntr = newObject.GetComponent<PonyInteractable>();
        PonyBehavior ponyBeh = newObject.GetComponent<PonyBehavior>();
        if (ponyIntr != null && ponyBeh != null)
        {
            ponyIntr.inventoryManager = inventoryManager;
            ponyBeh.gameManager = gameManager;
        }
        else
        {
            Debug.LogError("MyNewObject Script not found on prefab");
        }
    }
    public void SpawnApple()
    {
        //������ ��� �������
        Vector3 vectorForSpawn = new Vector3(Random.Range(3, 13), 3, Random.Range(0, -3));
        GameObject newObject = Instantiate(applePrefab, vectorForSpawn, Quaternion.identity);
        if (newObject.GetComponent<FoodInteractable>())
        {
            FoodInteractable food = newObject.GetComponent<FoodInteractable>();
            if (food != null)
            {
                food.inventoryManager = inventoryManager;
            }
            else
            {
                Debug.LogError("MyNewObject Script not found on prefab");
            }
        }
    }

    public void SpawnBurger()
    {
        //������� ���������� � ������
        Vector3 vectorForSpawn = new Vector3(Random.Range(-36, -48), 1, 2);
        GameObject newObject = Instantiate(burgerPrefab, vectorForSpawn, Quaternion.identity);
        PonyInteractable ponyIntr = newObject.GetComponent<PonyInteractable>();
        PonyBehavior ponyBeh = newObject.GetComponent<PonyBehavior>();
        if (ponyIntr != null && ponyBeh != null)
        {
            ponyIntr.inventoryManager = inventoryManager;
            ponyBeh.gameManager = gameManager;
        }
        else
        {
            Debug.LogError("MyNewObject Script not found on prefab");
        }
    }
    IEnumerator WaitSpawnPony()
    {
        yield return new WaitForSeconds(Random.Range(50f, 100f));
        //���� ������
        SpawnPony(); //������� ���� ����
        StartCoroutine(WaitSpawnPony());
    }
    IEnumerator WaitSpawnApple()
    {
        yield return new WaitForSeconds(Random.Range(30f, 60f));
        //���� ������
        SpawnApple(); //������� ���� ����
        StartCoroutine(WaitSpawnApple());
    }
}

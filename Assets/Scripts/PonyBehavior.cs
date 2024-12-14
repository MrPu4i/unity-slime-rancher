using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PonyBehavior : MonoBehaviour
{
    public float checkRadius = 2f;
    bool happines = false; //false - хочет кушать
    float jumpForce;
    float pushForce;
    bool flag = false;
    Rigidbody rb;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] public GameManager gameManager;

    private void Start()
    {
        StartCoroutine(WaitForJump());
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Не нашли Rigidbody!");
            enabled = false;
        }
    }
    private void Update()
    {
        if (happines == false)
        {
            CheckForFood();
        }
    }

    void CheckForFood()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Interact"))
            {
                if (collider.transform.GetComponent<InteractableObject>() is FoodInteractable)
                {
                    if (flag == false)
                    {
                        StartCoroutine(WaitForEat(collider.gameObject));
                        flag = true;
                    }
                }

            }
        }
    }
    IEnumerator WaitForEat(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);
        Eat(gameObject);
    }
    void Eat(GameObject gameObject)
    {
    //звуки поедания еды
    //уничтожаем объект рядом с нами
    Destroy(gameObject);
        //высираем денюжку
        Vector3 vectorForSpawn = new Vector3(transform.position.x + 3, transform.position.y, transform.position.z);
        GameObject newObject = Instantiate(coinPrefab, vectorForSpawn, Quaternion.identity);
        GoldInteractable coin = newObject.GetComponent<GoldInteractable>();
        coin.gameManager = gameManager;
        flag = false;
        happines = true;
        StartCoroutine(WaitForHappinesDown());
    }
    IEnumerator WaitForHappinesDown()
    {
        yield return new WaitForSeconds(20f);
        happines = false;
    }
    IEnumerator WaitForJump()
    {
        float wait = Random.Range(5f, 10f);
        yield return new WaitForSeconds(wait);
        Jump();
        StartCoroutine(WaitForJump());
    }
    void RandomNumbers()
    {
        jumpForce = Random.Range(2f, 10f);
        pushForce = Random.Range(1f, 3f);
        
    }
    void Jump()
    {
        RandomNumbers(); //каждый раз перед прыжком изменяем цифры
        if (rb != null)
        {
            Vector3 randomDirection = RandomDirection();
            Vector3 jumpDirection = transform.up;

            if (rb.linearVelocity.y < 2f)
            {
                rb.AddForce(randomDirection * pushForce, ForceMode.Impulse);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            }
        } 
    }
    Vector3 RandomDirection()
    {
        // Генерируем случайные значения для x и z (y игнорируем)
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        // Создаём вектор и нормализуем его
        Vector3 randomVector = new Vector3(randomX, 0f, randomZ);
        return randomVector.normalized;
    }

}

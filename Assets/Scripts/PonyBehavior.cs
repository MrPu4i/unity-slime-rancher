using System.Collections;
using UnityEngine;

public class PonyBehavior : MonoBehaviour
{
    public float checkRadius = 2f; // –адиус проверки (можно настраивать)
    bool happines = false; //false - хочет есть

    private void Update()
    {
        if (happines == false)
        {
            CheckForFood();  //ищем еду
        }
        
    }

    void CheckForFood()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Interact"))
            {
                if (collider.transform.GetComponent<InteractableObject>() is InteractableFood)
                {
                    //print("”–јјјјјјјјјјјјјјјјјј");
                    //нашли еду
                    StartCoroutine(WaitForEat());
                    
                }

            }
        }
    }

    IEnumerator WaitForEat()
    {
        yield return new WaitForSeconds(3f);
        Tell();
    }
    void Tell()
    {
        //print("подождали");
    }
    void Eat()
    {
        
    }
    void Jump()
    {
        gameObject.transform.position = new Vector3();
    }

}

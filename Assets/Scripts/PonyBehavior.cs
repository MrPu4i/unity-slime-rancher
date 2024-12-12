using System.Collections;
using UnityEngine;

public class PonyBehavior : MonoBehaviour
{
    public float checkRadius = 2f; // ������ �������� (����� �����������)
    bool happines = false; //false - ����� ����

    private void Update()
    {
        if (happines == false)
        {
            CheckForFood();  //���� ���
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
                    //print("��������������������");
                    //����� ���
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
        //print("���������");
    }
    void Eat()
    {
        
    }
    void Jump()
    {
        gameObject.transform.position = new Vector3();
    }

}

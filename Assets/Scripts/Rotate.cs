using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour
{
    //������ ������� ������������ �� y
    [SerializeField] private float rotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //�� ������ �����
    //����� �������� � ����� ������ �� ������, � ���������� ����� �� �� � ���-�� ����������������� ��� ���

    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 10f; //�� ����� ���������� ����� ����������������� � ��������

    Controls controls;
    InteractableObject io;
    [SerializeField] Image cursor;

    private void Start()
    {
        controls = new Controls(); //����������� ����������������� �����
        controls.Player.Enable();
        controls.Player.Interact.performed += Interact_performed;
    }
    private void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distance) && hit.transform.CompareTag("Interact"))
        //��������� ������� ������� ��������� ���, �� ������������
        //�� ���� ��� � ������-�� ���������, ���� ������������, ���������  true
        // ��� ������ �� ������

        //Vector3 origin - ������ ������ �����
        //Vector3 direction - �����������
        //����� ����
        //out RaycastHit hit - ���������� � �����������(������ �� ������, �� �������� �����������)
        { //������������ � ��������, � ������� ����� �����������������
                cursor.color = Color.white;
                cursor.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                io = hit.transform.GetComponent<InteractableObject>();
        }
        else 
        { 
            io = null;
            cursor.color = Color.red;
            cursor.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        io?.Interact(); //���� � io ���-�� ����, ����� ������ Interact()
    }
}

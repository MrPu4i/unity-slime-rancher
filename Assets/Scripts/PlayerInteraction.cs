using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //�� ������ �����
    //����� �������� � ����� ������ �� ������, � ���������� ����� �� �� � ���-�� ����������������� ��� ���

    [SerializeField] Camera cam;
    [SerializeField] float distance = 10f; //�� ����� ���������� ����� ����������������� � ��������
    [SerializeField] Animator anim_text_wall_cost;
    [SerializeField] Animator anim_text_genshin;
    [SerializeField] TextMeshProUGUI text_wall_cost;
    [SerializeField] Image cursor;
    [SerializeField] InteractableButton but1;
    [SerializeField] InteractableButton but2;
    
    Controls controls;
    InteractableObject io;

    private void Start()
    {
        Console.WriteLine("���");
        controls = new Controls(); //����������� ����������������� �����
        controls.Player.Enable();
        controls.Player.Interact.performed += Interact_performed;
    }
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distance) && hit.transform.CompareTag("Interact"))
        //��������� ������� ������� ��������� ���, �� ������������
        //�� ���� ��� � ������-�� ���������, ���� ������������, ���������  true
        // ��� ������ �� ������

        //Vector3 origin - ������ ������ �����
        //Vector3 direction - �����������
        //����� ����
        //out RaycastHit hit - ���������� � �����������(������ �� ������, �� �������� �����������)
        { //������������ � ��������, � ������� ����� �����������������
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
            cursor.color = Color.white;
            cursor.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            io = hit.transform.GetComponent<InteractableObject>();
            //���� ����� �������� ����� ��� ���������
            if (io is InteractableButton)
            {
                anim_text_wall_cost.SetBool("fade", false);
            }
            if (io is PCInteractable)
            {
                anim_text_genshin.SetBool("fade", false);
            }
        }
        else 
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            io = null;
            cursor.color = Color.red;
            cursor.transform.localScale = new Vector3(1f, 1f, 1f);
            anim_text_wall_cost.SetBool("fade", true);
            anim_text_genshin.SetBool("fade", true);

        }

    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        io?.Interact(); //���� � io ���-�� ����, ����� ������ Interact()
    }
}

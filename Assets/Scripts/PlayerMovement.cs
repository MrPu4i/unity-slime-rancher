using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float GrSpeed = 10;
    [SerializeField] private float AirSpeed = 5;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;


    Controls controls;
    float velocity;
    bool jump = false;
    float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Player.Enable();
        controls.Player.Jump.performed += Jump_performed;
    }
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (characterController.isGrounded)
        {
            velocity = Mathf.Sqrt(-jumpHeight * gravity);
            jump = true;  // ��������� ��� ������ ����� �������
        }
    }
    void Update()
    {
        //������ ����� �������
        if (characterController.isGrounded && !jump)  // ���������
        {
            velocity = -Mathf.Epsilon; //�������� ���������� ���������, 0 ����� �� ����, ��� ����� ��������� ����, ������� ����
            speed = GrSpeed;
        }
        else 
        { 
            speed = AirSpeed;
            //���� �������� ������ ����� �� ����� - �������� �������� ����, � ������� - ������
            //�������� ����� �� ����� ���, ��� ������������� �� speed. ����� ������� ��� ���������, ��� �������� ��� ����� � �������
        }
        jump = false; // ���������

        Vector2 v = controls.Player.Movement.ReadValue<Vector2>();
        velocity += gravity * Time.deltaTime;
            Vector3 movement = (transform.right * v.x + transform.forward * v.y) * speed
            + Vector3.up * velocity;
        //�� ����������� �����������, � ����������� � ������� ����� ��������� ����.
            characterController.Move(movement * Time.deltaTime);

        ////������ ����� if
        //if (characterController.isGrounded)  // ��������� v2
        //{
        //    velocity = -Mathf.Epsilon;
        //}
        //if (controls.Player.Jump.WasPerformedThisFrame()) // ��������� v2
        //    velocity = Mathf.Sqrt(-jumpHeight * gravity);
    }
}

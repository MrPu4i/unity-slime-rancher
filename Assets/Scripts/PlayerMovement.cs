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
            jump = true;  // изменения для прыжка через событие
        }
    }
    void Update()
    {
        //прыжок через событие
        if (characterController.isGrounded && !jump)  // изменения
        {
            velocity = -Mathf.Epsilon; //скорость становится маленькой, 0 лучше не надо, нам нужна небольшая сила, давящая вниз
            speed = GrSpeed;
        }
        else 
        { 
            speed = AirSpeed;
            //если колайдер игрока стоит на земле - скорость движения одна, в воздухе - другая
            //например когда на земле чел, оно увеличивается на speed. Можно сделать два параметра, две скорости для земли и воздуха
        }
        jump = false; // изменения

        Vector2 v = controls.Player.Movement.ReadValue<Vector2>();
        velocity += gravity * Time.deltaTime;
            Vector3 movement = (transform.right * v.x + transform.forward * v.y) * speed
            + Vector3.up * velocity;
        //не определение направления, а направление в которое нужно приложить силу.
            characterController.Move(movement * Time.deltaTime);

        ////прыжок через if
        //if (characterController.isGrounded)  // изменения v2
        //{
        //    velocity = -Mathf.Epsilon;
        //}
        //if (controls.Player.Jump.WasPerformedThisFrame()) // изменения v2
        //    velocity = Mathf.Sqrt(-jumpHeight * gravity);
    }
}

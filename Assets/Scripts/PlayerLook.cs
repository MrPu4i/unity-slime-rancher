using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensetivity = 1f;
    [SerializeField] private Transform player;

    Controls controls;

    void Start()
    {
        controls = new Controls();
        controls.Player.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    }

    float rotation = 0;

    void Update()
    {
        Vector2 v = controls.Player.Look.ReadValue<Vector2>() * mouseSensetivity;

        rotation -= v.y;
        rotation = Mathf.Clamp(rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(rotation, 0, 0);

        player.Rotate(Vector3.up * v.x);
    }
}

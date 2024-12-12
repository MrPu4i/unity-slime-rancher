using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //на игроке висит
    //будем смотреть в какой объект мы попали, и определять можем ли мы с кем-то взаимодействовать или нет

    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 10f; //на каком расстоянии можем взаимодействовать с объектом
    [SerializeField] private Animator anim_text_wall_cost;
    [SerializeField] Image cursor;
    
    Controls controls;
    InteractableObject io;

    private void Start()
    {
        Console.WriteLine("лол");
        controls = new Controls(); //считываение пользовательского ввода
        controls.Player.Enable();
        controls.Player.Interact.performed += Interact_performed;
    }
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distance) && hit.transform.CompareTag("Interact"))
        //некоторая функция которая выпускает луч, не пересекается
        //ли этот луч с какими-то объектами, если пересекается, возращает  true
        // даёт ссылку на объект

        //Vector3 origin - откуда поедет точка
        //Vector3 direction - направление
        //длина луча
        //out RaycastHit hit - информация о пересечении(ссылка на объект, до которого дотронулась)
        { //пересекаемся с объектом, с которым можно взаимодействовать
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
            cursor.color = Color.white;
            cursor.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            io = hit.transform.GetComponent<InteractableObject>();
            //хочу чтобы появился текст про стоимость
            if (io is InteractableButton)
            {
                anim_text_wall_cost.SetBool("fade", false);
            }
        }
        else 
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            io = null;
            cursor.color = Color.red;
            cursor.transform.localScale = new Vector3(1f, 1f, 1f);
            anim_text_wall_cost.SetBool("fade", true);
          
        }

    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        io?.Interact(); //если в io что-то есть, тогда делаем Interact()
    }
}

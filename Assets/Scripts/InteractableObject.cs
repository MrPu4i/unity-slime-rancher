using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // наследоваться все скрипты для всех остальных объектов

    [SerializeField] protected bool interactable;

    private void Awake() //вызывается перед стартом
    {
        if (interactable)
            tag = "Interact";
    }
    public void SetInteractable(bool _interactable)
    {
        this.interactable = _interactable;
        if (interactable)
        {
            tag = "Interact";
        }
        else
        {
            tag = "Untagged";
        }
    }
    public virtual void Interact()
    {
        print("Interact with" + gameObject);

        //что происходит когда интерактимся    
        //виртуальный тк разные объекты делают разные вещи
    }

}

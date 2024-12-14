using UnityEngine;

public class GoldInteractable : InteractableObject
{
    [SerializeField] float price;
    public GameManager gameManager;

    public override void Interact()
    {
        gameManager.Money += price;
        Destroy(gameObject);
    }
}

using UnityEngine;

public class PCInteractable : InteractableObject
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioClip soundToPlay;
    [SerializeField] AudioClip soundToPlay_noMoney;
    public override void Interact()
    {
        if (gameManager.Money >= 50)
        {
            gameManager.Money -= 50;
            //звуки япии, поздравления, вспышки
            AudioSource.PlayClipAtPoint(soundToPlay, Vector3.zero, 1f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(soundToPlay_noMoney, Vector3.zero, 3f);
            //звуки запрета
        }
    }
}

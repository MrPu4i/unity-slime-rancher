using UnityEngine;

public class InteractableButton : InteractableObject
{
    [SerializeField] private GameObject sh_button;
    Material material;
    void Start()
    {
        material = sh_button.GetComponent<Renderer>().material;
    }

    public override void Interact()
    {
        //��������� ���� ������ ������.
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}

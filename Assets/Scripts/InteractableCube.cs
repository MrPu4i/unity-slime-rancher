using UnityEngine;

public class InteractableCube : InteractableObject
{
    [SerializeField] private GameObject cube;
    Material material;
    private void Start()
    {
        material = cube.GetComponent<Renderer>().material; //renderer отвечает за рендер объекта, в нём есть инфа про материал
    }
    public override void Interact()
    {
        cube.SetActive(true);
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}

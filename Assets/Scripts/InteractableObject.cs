using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // ������������� ��� ������� ��� ���� ��������� ��������

    [SerializeField] protected bool interactable;

    private void Awake() //���������� ����� �������
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

        //��� ���������� ����� ������������    
        //����������� �� ������ ������� ������ ������ ����
    }

}

using System;
using UnityEngine;

public class AllRaycast : MonoBehaviour
{
    public static event Action OnRaycast;
    [SerializeField]
    private GameObject ImageAction;// �������� � ���������
    private void Update()
    {
        // ������� ��� �� ������ � ����������� �������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // ��������� raycast
        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.tag != "Untagged")
            {
                ImageAction.SetActive(true);// ���������� ��������� ��� ������
                OnRaycast?.Invoke();
            }
        }
        else
        {
            ImageAction.SetActive(false);
        }
    }
}

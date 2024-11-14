using System;
using TMPro;
using UnityEngine;

public class AllRaycast : MonoBehaviour
{
    public static event Action<string> OnRaycast;

    /// <summary>
    /// �� ������������ ������� �������� �������� ����������� ��� �������
    /// </summary>
    public static event Action<string, GameObject> OnRaycastAction;

    public static event Action<bool, GameObject, string> OnRaycastTovar;
    [SerializeField]
    private GameObject ImageAction;// �������� � ���������
    [SerializeField]
    [Header("����� � ���-�� ��������� � �������")]
    private GameObject TextValueBox;// �������� c ���-�� � ��������

    public LayerMask targetLayer;
    private void LateUpdate()
    {
        // ������� ��� �� ������ � ����������� �������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // ��������� raycast
        if (Physics.Raycast(ray, out hit, 2, targetLayer))
        {
            if (hit.collider.tag != "Untagged")
            {
                if(hit.collider.tag == "Box")
                {
                    TextValueBox.SetActive(true);
                    TextMeshProUGUI textBox;
                    textBox = TextValueBox.GetComponent<TextMeshProUGUI>();

                    BoxProduct boxProduct;
                    boxProduct = hit.collider.GetComponent<BoxProduct>();

                    textBox.text = boxProduct.stackValue + "/" + boxProduct.value;
                }

                ImageAction.SetActive(true);// ���������� ��������� ��� ������
                OnRaycast?.Invoke(hit.collider.tag);
                OnRaycastAction?.Invoke(hit.collider.tag, hit.collider.gameObject);

                OnRaycastTovar?.Invoke(true, hit.collider.gameObject, hit.collider.tag);
            }
        }
        else
        {
            ImageAction.SetActive(false);
            TextValueBox.SetActive(false);
            //OnRaycastTovar?.Invoke(false, null, "");
        }
    }
}

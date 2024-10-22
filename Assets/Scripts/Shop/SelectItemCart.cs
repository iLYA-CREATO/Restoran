using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemCart : MonoBehaviour
{
    public static event Action<Products, GameObject> MinusItem;
    [Header("������ ��������")]
    public Button buttonMinus;

    [Header("����� �������� �������")]
    public TextMeshProUGUI textName;

    [Header("����� ���������")]
    public TextMeshProUGUI textPrice;

    [Header("����� ���-��")]
    public TextMeshProUGUI textValue;

    [Header("����� ���-��")]
    public TextMeshProUGUI textValueBoxes;

    [Header("������ ��������")]
    public Products productsItem;

    /// <summary>
    /// ����������� �� �������� �������
    /// </summary>
    public void _MinusItem()
    {
        MinusItem?.Invoke(productsItem, gameObject);
    }
}

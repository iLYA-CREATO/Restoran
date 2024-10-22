using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemCart : MonoBehaviour
{
    public static event Action<Products, GameObject> MinusItem;
    [Header("Кнопка действия")]
    public Button buttonMinus;

    [Header("Текст названия позиции")]
    public TextMeshProUGUI textName;

    [Header("Текст стоимости")]
    public TextMeshProUGUI textPrice;

    [Header("Текст кол-во")]
    public TextMeshProUGUI textValue;

    [Header("Текст кол-во")]
    public TextMeshProUGUI textValueBoxes;

    [Header("Кнопка действия")]
    public Products productsItem;

    /// <summary>
    /// Прокидываем на удаление объекта
    /// </summary>
    public void _MinusItem()
    {
        MinusItem?.Invoke(productsItem, gameObject);
    }
}

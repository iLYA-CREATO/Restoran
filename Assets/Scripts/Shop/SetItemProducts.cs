using System;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class SetItemProducts : MonoBehaviour
{
    public Products products;

    [SerializeField]
    [Header("Текст названия")]
    private TextMeshProUGUI textNameTovar;
    [SerializeField]
    [Header("Текст стоимости")]
    private TextMeshProUGUI textPriceTovar;
    private void Start()
    {
        textNameTovar.text = products.nameProducts;
        textPriceTovar.text = products.priceProducts.ToString();
    }


}

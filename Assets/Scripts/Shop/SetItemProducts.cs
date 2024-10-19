using TMPro;
using UnityEngine;

public class SetItemProducts : MonoBehaviour
{
    public Products products;

    [SerializeField]
    [Header("����� ��������")]
    private TextMeshProUGUI textNameTovar;
    [SerializeField]
    [Header("����� ���������")]
    private TextMeshProUGUI textPriceTovar;
    private void Start()
    {
        textNameTovar.text = products.nameProducts.nameProductsRus;
        textPriceTovar.text = products.priceProducts.ToString();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ������ ��� ���������� ������� ��������� ��������
/// </summary>
public class SetItemProducts : MonoBehaviour
{
    public Products products;

    [SerializeField]
    [Header("����� ��������")]
    private TextMeshProUGUI textNameTovar;
    [SerializeField]
    [Header("����� ���������")]
    private TextMeshProUGUI textPriceTovar;
    [SerializeField]
    [Header("������ ������")]
    private Image iconTovarShop;
    private void Start()
    {
        textNameTovar.text = products.nameProducts;
        textPriceTovar.text = products.priceProducts.ToString();
        iconTovarShop.sprite = products.iconProduct;
    }
}

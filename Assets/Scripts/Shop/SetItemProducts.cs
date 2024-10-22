using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Скрипт для заполнения данными карточкув магазине
/// </summary>
public class SetItemProducts : MonoBehaviour
{
    public Products products;

    [SerializeField]
    [Header("Текст названия")]
    private TextMeshProUGUI textNameTovar;
    [SerializeField]
    [Header("Текст стоимости")]
    private TextMeshProUGUI textPriceTovar;
    [SerializeField]
    [Header("Иконка товара")]
    private Image iconTovarShop;
    private void Start()
    {
        textNameTovar.text = products.nameProducts;
        textPriceTovar.text = products.priceProducts.ToString();
        iconTovarShop.sprite = products.iconProduct;
    }
}

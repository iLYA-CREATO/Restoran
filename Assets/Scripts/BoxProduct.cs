using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>

public class BoxProduct : Tovar
{
    public Products productsSO;
    public Image iconTovarLeft;
    public Image iconTovarRight;

    public void Start()
    {
        SetData();
    }
    
    /// <summary>
    /// Метод заполняет даные
    /// </summary>
    private void SetData()
    {
        nameTovar = productsSO.nameProducts;

        priceTovar = productsSO.priceProducts;

        // Берем стартовое кол-во из префаба
        stackValue = productsSO.valueProductsStack;

        iconTovarLeft.sprite = productsSO.iconProduct;
        iconTovarRight.sprite = productsSO.iconProduct;

        // заполняем кол-во товара в коробки при покупки
        value = stackValue;
    }
}

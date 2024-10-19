using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Сам инвентарь корзины
/// </summary>
public class ShoppingCart : MonoBehaviour
{
    public List<ProductData> products;
    [SerializeField]
    private AddShoppingCart addShoppingCart;
    public void _AddShoppingCart(SetItemProducts productsGetBtutton)
    {
        Add(productsGetBtutton);
    }

    private void Add(SetItemProducts productsGetBtutton)
    {
        products.Add(new ProductData
        {
            productsData = productsGetBtutton.products,
            productsPriceData = productsGetBtutton.products.priceProducts,
            langProducts = productsGetBtutton.products.nameProducts
        }) ;

        addShoppingCart.UIAddItem();
    }
}

[Serializable]
public class ProductData
{
    [Header("Ссылка на товар")]
    public Products productsData;
    [Header("Стоимость товара")]
    public float productsPriceData;
    [Header("Название на разных языках")]
    public lang langProducts;
}

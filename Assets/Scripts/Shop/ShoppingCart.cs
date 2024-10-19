using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ��� ��������� �������
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
    [Header("������ �� �����")]
    public Products productsData;
    [Header("��������� ������")]
    public float productsPriceData;
    [Header("�������� �� ������ ������")]
    public lang langProducts;
}

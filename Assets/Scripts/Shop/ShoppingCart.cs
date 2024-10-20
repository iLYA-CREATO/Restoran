using System;
using System.Collections.Generic;
using System.Linq;
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
        // ��� ������ �������� ������ �������
        if(products.Count == 0)
        {
            products.Add(new ProductData
            {
                productsData = productsGetBtutton.products,
                productsPriceData = productsGetBtutton.products.priceProducts,
                nameProducts = productsGetBtutton.products.nameProducts,
                productsValueData = productsGetBtutton.products.valueProducts,
            });
            addShoppingCart.UICreateAddItem(products.Last());
        }// ��� ��� ����� ��������� �� ��������
        else if(products.Count > 0)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (productsGetBtutton.products.nameProducts == products[i].nameProducts)
                {
                    products[i].productsPriceData += productsGetBtutton.products.priceProducts;
                    products[i].productsValueData += productsGetBtutton.products.valueProducts;
                    addShoppingCart.UIUpdateItem(products[i]);
                }
                else
                {
                    Debug.Log("��� ���-�� �����");
                }
            }
        } 
    }

    /// <summary>
    /// ������� ������ 1 ��������
    /// </summary>
    public void ClearUIItem(Products _products, GameObject ItemCart)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].nameProducts == _products.nameProducts)
            {
                if(products[i].productsValueData > _products.valueProducts)
                {
                    products[i].productsValueData -= _products.valueProducts;
                    products[i].productsPriceData -= _products.priceProducts;

                    addShoppingCart.UIUpdateItem(products[i]);
                }
                else
                {
                    Destroy(ItemCart);

                    // ��� ����� ��� ��������� �� �������� 
                    // ������ �� ��������� Data
                }
            }
        }
    }

    private void OnEnable()
    {
        SelectItemCart.MinusItem += ClearUIItem;
    }

    private void OnDisable()
    {
        SelectItemCart.MinusItem -= ClearUIItem;
    }
}

[Serializable]
public class ProductData
{
    [Header("������ �� �����")]
    public Products productsData;
    [Header("��������� ������")]
    public float productsPriceData;
    [Header("���-�� ������")]
    public float productsValueData;
    [Header("�������� �� ������ ������")]
    public string nameProducts;
}

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

    private void Add(SetItemProducts productsGetButton)
    {
        // ���������, ���� �� �������� � �������
        if (products.Count == 0)
        {
            // ��������� ������ ������� � �������
            AddNewProduct(productsGetButton);
        }
        else
        {
            // ���������� ��� ������������ ������������� ��������
            bool productExists = false;

            // ��������� ������������ �������� � �������
            for (int i = 0; i < products.Count; i++)
            {
                if (productsGetButton.products.nameProducts == products[i].nameProducts)
                {
                    // ���� ������� ����������, ��������� ��� ������
                    products[i].productsPriceData += productsGetButton.products.priceProducts;
                    products[i].productsValueData += productsGetButton.products.valueProducts;
                    products[i].productsValueBoxesData += 1;
                    addShoppingCart.UIUpdateItem(products[i]);
                    productExists = true;
                    break; // ������� �� �����, �.�. ������� ������
                }
            }

            // ���� ������� �� ������, ��������� ��� ��� �����
            if (!productExists)
            {
                Debug.Log("��������� ����� �������");
                AddNewProduct(productsGetButton);
            }
        }
    }

    // ����� ��� ���������� ������ ��������
    private void AddNewProduct(SetItemProducts productsGetButton)
    {
        products.Add(new ProductData
        {
            productsData = productsGetButton.products,
            productsPriceData = productsGetButton.products.priceProducts,
            nameProducts = productsGetButton.products.nameProducts,
            productsValueData = productsGetButton.products.valueProducts,
            productsValueBoxesData = productsGetButton.products.valueProductsBoxes
        });

        addShoppingCart.UICreateAddItem(products.Last());
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
                if(products[i].productsValueBoxesData >= 1)
                {
                    products[i].productsValueData -= _products.valueProducts;
                    products[i].productsPriceData -= _products.priceProducts;
                    products[i].productsValueBoxesData -= 1;
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
    // ����� ������� ��� ��� ���� ��� ����� ����
    public Products productsData;
    [Header("��������� ������")]
    public float productsPriceData;
    [Header("���-�� ������")]
    public float productsValueData;

    [Header("�������� �� ������ ������")]
    public string nameProducts;

    [Header("���-�� �������")]
    public int productsValueBoxesData;
}

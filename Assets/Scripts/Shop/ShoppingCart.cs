using System;
using System.Collections.Generic;
using System.Linq;
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
        // Тут просто создадим первый элемент
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
        }// тут уже будем проверять на схожесть
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
                    Debug.Log("Это что-то новое");
                }
            }
        } 
    }

    /// <summary>
    /// Удаляет нужный 1 эелемент
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

                    // Тут нужно ещё прокинуть на удаление 
                    // данных из инвенторя Data
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
    [Header("Ссылка на товар")]
    public Products productsData;
    [Header("Стоимость товара")]
    public float productsPriceData;
    [Header("Кол-во товара")]
    public float productsValueData;
    [Header("Название на разных языках")]
    public string nameProducts;
}

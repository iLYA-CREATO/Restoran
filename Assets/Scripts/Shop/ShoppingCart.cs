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

    private void Add(SetItemProducts productsGetButton)
    {
        // Проверяем, есть ли продукты в корзине
        if (products.Count == 0)
        {
            // Добавляем первый продукт в корзину
            AddNewProduct(productsGetButton);
        }
        else
        {
            // Переменная для отслеживания существующего продукта
            bool productExists = false;

            // Проверяем существующие продукты в корзине
            for (int i = 0; i < products.Count; i++)
            {
                if (productsGetButton.products.nameProducts == products[i].nameProducts)
                {
                    // Если продукт существует, обновляем его данные
                    products[i].productsPriceData += productsGetButton.products.priceProducts;
                    products[i].productsValueData += productsGetButton.products.valueProducts;
                    products[i].productsValueBoxesData += 1;
                    addShoppingCart.UIUpdateItem(products[i]);
                    productExists = true;
                    break; // Выходим из цикла, т.к. продукт найден
                }
            }

            // Если продукт не найден, добавляем его как новый
            if (!productExists)
            {
                Debug.Log("Добавляем новый продукт");
                AddNewProduct(productsGetButton);
            }
        }
    }

    // Метод для добавления нового продукта
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
    /// Удаляет нужный 1 эелемент
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
    // Очент полезно так как буду тут брать инфу
    public Products productsData;
    [Header("Стоимость товара")]
    public float productsPriceData;
    [Header("Кол-во товара")]
    public float productsValueData;

    [Header("Название на разных языках")]
    public string nameProducts;

    [Header("Кол-во коробок")]
    public int productsValueBoxesData;
}

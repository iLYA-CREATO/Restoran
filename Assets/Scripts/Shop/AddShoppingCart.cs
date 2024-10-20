using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Скрипт будет добавлять в корзину товар визуально
/// </summary>
public class AddShoppingCart : MonoBehaviour
{
    [SerializeField, Header("Префаб Item карты в корзине")]
    private GameObject prebabItemCart;

    [SerializeField, Header("Место где будем создвать наши позиции в корзине")]
    private Transform spawnPos;

    [SerializeField, Header("Хранилище UI данных")]
    private List<SelectItemCart> spawnList;
    public void UICreateAddItem(ProductData products)
    {
        SelectItemCart buferCreate;
        Debug.Log(products.productsValueData + " " + products.productsPriceData);
        buferCreate = Instantiate(prebabItemCart, spawnPos).GetComponent<SelectItemCart>();
        
        // Также добавляем всё в список
        spawnList.Add(buferCreate);

        // Заполняем данными
        buferCreate.productsItem = products.productsData;
        buferCreate.textName.text = products.nameProducts;
        buferCreate.textPrice.text = products.productsPriceData.ToString();
        buferCreate.textValue.text = products.productsValueData.ToString();
    }
    /// <summary>
    /// Метод для обнавление визуальных данных
    /// </summary>
    /// <param name="products"></param>
    public void UIUpdateItem(ProductData products)
    {
        for(int i = 0; i < spawnList.Count; i++)
        {
            // Проверяю через текст который уже хранит в себе название 
            // И если всё good то обнавляем
            if (products.nameProducts == spawnList[i].textName.text)
            {
                spawnList[i].textName.text = products.nameProducts;
                spawnList[i].textPrice.text = products.productsPriceData.ToString();
                spawnList[i].textValue.text = products.productsValueData.ToString();
            }
        }
    }

    public void RemovedCartUI()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            Destroy(spawnList[i].gameObject);
        }
        spawnList.Clear();
    }
}


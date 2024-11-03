using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Products", menuName = "ScriptbleObject/Products")]
public class Products : ScriptableObject
{
    [Header("Название товара")]
    public string nameProducts;

    [Header("Стоимость товара")]
    public float priceProducts;

    [Header("Кол-во при покупке товара")]
    public float valueProductsStack;

    [Header("Просто кол-во товара")]
    public float valueProducts;

    [Header("Кол-во коробок")]
    public int valueProductsBoxes = 1;

    [Header("Иконка продукта")]
    public Sprite iconProduct;

    [Header("Продукция которая не находится в пластике")]
    public bool NotPackage;
}

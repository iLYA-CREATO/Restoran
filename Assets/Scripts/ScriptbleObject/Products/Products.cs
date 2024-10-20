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
    public float valueProducts;
}

/*[Serializable]
public class lang
{
    [Header("Русский")]
    public string nameProductsRus;
    [Header("Английский")]
    public string nameProductsEng;
    [Header("Турецкий")]
    public string nameProductsTur;
}*/

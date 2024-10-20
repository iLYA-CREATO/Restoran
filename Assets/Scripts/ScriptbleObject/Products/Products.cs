using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Products", menuName = "ScriptbleObject/Products")]
public class Products : ScriptableObject
{
    [Header("�������� ������")]
    public string nameProducts;

    [Header("��������� ������")]
    public float priceProducts;

    [Header("���-�� ��� ������� ������")]
    public float valueProducts;
}

/*[Serializable]
public class lang
{
    [Header("�������")]
    public string nameProductsRus;
    [Header("����������")]
    public string nameProductsEng;
    [Header("��������")]
    public string nameProductsTur;
}*/

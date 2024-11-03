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
    public float valueProductsStack;

    [Header("������ ���-�� ������")]
    public float valueProducts;

    [Header("���-�� �������")]
    public int valueProductsBoxes = 1;

    [Header("������ ��������")]
    public Sprite iconProduct;

    [Header("��������� ������� �� ��������� � ��������")]
    public bool NotPackage;
}

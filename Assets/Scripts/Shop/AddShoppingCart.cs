using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ������ ����� ��������� � ������� ����� ���������
/// </summary>
public class AddShoppingCart : MonoBehaviour
{
    [SerializeField, Header("������ Item ����� � �������")]
    private GameObject prebabItemCart;

    [SerializeField, Header("����� ��� ����� �������� ���� ������� � �������")]
    private Transform spawnPos;

    [SerializeField, Header("��������� UI ������")]
    private List<SelectItemCart> spawnList;
    public void UICreateAddItem(ProductData products)
    {
        SelectItemCart buferCreate;
        Debug.Log(products.productsValueData + " " + products.productsPriceData);
        buferCreate = Instantiate(prebabItemCart, spawnPos).GetComponent<SelectItemCart>();
        
        // ����� ��������� �� � ������
        spawnList.Add(buferCreate);

        // ��������� �������
        buferCreate.productsItem = products.productsData;
        buferCreate.textName.text = products.nameProducts;
        buferCreate.textPrice.text = products.productsPriceData.ToString();
        buferCreate.textValue.text = products.productsValueData.ToString();
    }
    /// <summary>
    /// ����� ��� ���������� ���������� ������
    /// </summary>
    /// <param name="products"></param>
    public void UIUpdateItem(ProductData products)
    {
        for(int i = 0; i < spawnList.Count; i++)
        {
            // �������� ����� ����� ������� ��� ������ � ���� �������� 
            // � ���� �� good �� ���������
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


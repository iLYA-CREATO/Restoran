using System;
using System.Collections;
using UnityEngine;

public class PayShoppingCart : MonoBehaviour
{
    public static event Action PayShopping;

    [SerializeField]
    private ShoppingCart shoppingCart;

    [SerializeField]
    private AddShoppingCart addShoppingCart;

    [SerializeField]
    [Header("������ �������")]
    private GameObject prebasItemObject;

    [SerializeField]
    [Header("����� ���������")]
    private Transform spawnPosition; // ����� ����� ������� ����� ���������
    /// <summary>
    /// ����� ��� ������
    /// </summary>
    public void Pay()
    {
        for (int i = 0; i < shoppingCart.products.Count; i++)
        {
            if (shoppingCart.products[i].productsData == shoppingCart.products[i].productsData)
            {
                for(int j = 0; j < shoppingCart.products[i].productsValueBoxesData; j++)
                {
                   SpawnObject(i);
                }
            }
        }

        // ����� ������ � ������ ������� ��� �������
        shoppingCart.products.Clear();
        addShoppingCart.RemovedCartUI();
        PayShopping?.Invoke();
    }

    private void SpawnObject(int id)
    {
        BoxProduct buferSpawnTovar;
        buferSpawnTovar = Instantiate(prebasItemObject, spawnPosition).GetComponent<BoxProduct>();
        buferSpawnTovar.productsSO = shoppingCart.products[id].productsData;

        // ���� ����� �������� �������� � ����� ������ ��������� 
        // ���������� �� shoppingCart.products[id].productsData;   
    }
}

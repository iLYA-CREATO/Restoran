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
    [Header("Префаб объекта")]
    private GameObject prebasItemObject;

    [SerializeField]
    [Header("Место появление")]
    private Transform spawnPosition; // Можно будет сделать потом рандомным
    /// <summary>
    /// Метод для оплаты
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

        // После оплаты и спавна удаляем всю корзину
        shoppingCart.products.Clear();
        addShoppingCart.RemovedCartUI();
        PayShopping?.Invoke();
    }

    private void SpawnObject(int id)
    {
        BoxProduct buferSpawnTovar;
        buferSpawnTovar = Instantiate(prebasItemObject, spawnPosition).GetComponent<BoxProduct>();
        buferSpawnTovar.productsSO = shoppingCart.products[id].productsData;

        // Пока вроде проверка работает и будем раюать используя 
        // информацию из shoppingCart.products[id].productsData;   
    }
}

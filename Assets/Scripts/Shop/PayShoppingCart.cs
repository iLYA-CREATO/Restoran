using Unity.VisualScripting;
using UnityEngine;

public class PayShoppingCart : MonoBehaviour
{
    [SerializeField]
    private ShoppingCart shoppingCart;
    [SerializeField]
    private AddShoppingCart addShoppingCart;

    [SerializeField]
    private GameObject prebasItemObject;
    [SerializeField]
    private Transform spawnPosition;
    /// <summary>
    /// Метод для оплаты
    /// </summary>
    public void Pay()
    {
        for (int i = 0; i < shoppingCart.products.Count; i++)
        {
            SpawnCart();
        }
        // После оплаты и спавна удаляем всю корзину
        shoppingCart.products.Clear();
        addShoppingCart.RemovedCartUI();
    }

    // После оплаты мы должны создать все товары которые игрок оплатил

    private void SpawnCart()
    {
        Instantiate(prebasItemObject, spawnPosition);
    }
}

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
    /// ����� ��� ������
    /// </summary>
    public void Pay()
    {
        for (int i = 0; i < shoppingCart.products.Count; i++)
        {
            SpawnCart();
        }
        // ����� ������ � ������ ������� ��� �������
        shoppingCart.products.Clear();
        addShoppingCart.RemovedCartUI();
    }

    // ����� ������ �� ������ ������� ��� ������ ������� ����� �������

    private void SpawnCart()
    {
        Instantiate(prebasItemObject, spawnPosition);
    }
}

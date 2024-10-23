using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>

public class BoxProduct : Tovar
{
    public Products productsSO;
    public Image iconTovarLeft;
    public Image iconTovarRight;

    public void Start()
    {
        SetData();
    }
    
    /// <summary>
    /// ����� ��������� �����
    /// </summary>
    private void SetData()
    {
        nameTovar = productsSO.nameProducts;

        priceTovar = productsSO.priceProducts;

        // ����� ��������� ���-�� �� �������
        stackValue = productsSO.valueProductsStack;

        iconTovarLeft.sprite = productsSO.iconProduct;
        iconTovarRight.sprite = productsSO.iconProduct;

        // ��������� ���-�� ������ � ������� ��� �������
        value = stackValue;
    }
}

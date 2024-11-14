using System;
using TMPro;
using UnityEngine;

public class AllRaycast : MonoBehaviour
{
    public static event Action<string> OnRaycast;

    /// <summary>
    /// Он обрабатывает обычные действия например холодильник или мусорка
    /// </summary>
    public static event Action<string, GameObject> OnRaycastAction;

    public static event Action<bool, GameObject, string> OnRaycastTovar;
    [SerializeField]
    private GameObject ImageAction;// Картинка с действием
    [SerializeField]
    [Header("Текст с кол-во предметов в коробке")]
    private GameObject TextValueBox;// Картинка c кол-во в коробках

    public LayerMask targetLayer;
    private void LateUpdate()
    {
        // Создаем луч из камеры в направлении взгляда
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Выполняем raycast
        if (Physics.Raycast(ray, out hit, 2, targetLayer))
        {
            if (hit.collider.tag != "Untagged")
            {
                if(hit.collider.tag == "Box")
                {
                    TextValueBox.SetActive(true);
                    TextMeshProUGUI textBox;
                    textBox = TextValueBox.GetComponent<TextMeshProUGUI>();

                    BoxProduct boxProduct;
                    boxProduct = hit.collider.GetComponent<BoxProduct>();

                    textBox.text = boxProduct.stackValue + "/" + boxProduct.value;
                }

                ImageAction.SetActive(true);// Активируем подсказку для игрока
                OnRaycast?.Invoke(hit.collider.tag);
                OnRaycastAction?.Invoke(hit.collider.tag, hit.collider.gameObject);

                OnRaycastTovar?.Invoke(true, hit.collider.gameObject, hit.collider.tag);
            }
        }
        else
        {
            ImageAction.SetActive(false);
            TextValueBox.SetActive(false);
            //OnRaycastTovar?.Invoke(false, null, "");
        }
    }
}

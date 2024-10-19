using System;
using UnityEngine;

public class AllRaycast : MonoBehaviour
{
    public static event Action OnRaycast;
    [SerializeField]
    private GameObject ImageAction;// Картинка с действием
    private void Update()
    {
        // Создаем луч из камеры в направлении взгляда
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Выполняем raycast
        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.tag != "Untagged")
            {
                ImageAction.SetActive(true);// Активируем подсказку для игрока
                OnRaycast?.Invoke();
            }
        }
        else
        {
            ImageAction.SetActive(false);
        }
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


/// <summary>
/// Скрипт отчвечает за подбор предметов
/// </summary>
public class RaiseTovar : MonoBehaviour
{
    public static event Action<GameObject,bool> OnGetBox;
    [SerializeField]
    [Header("")]
    private Transform raisPosition;

    [SerializeField]
    [Header("")]
    private Transform spawnPosition;
    [SerializeField]
    [Header("Поднят ли предмет")]
    private bool isTake;

    [SerializeField]
    [Header("Какой предмет поднят")]
    private GameObject raiseObject;

    private void OnEnable()
    {
        AllRaycast.OnRaycastTovar += OnRaise;
        Put.OnDropBox += DropBox; // Коробку поставили
        Put.OnResetToPlayerBox += ResetBoxToPlayer;

    }
    private void OnDisable()
    {
        AllRaycast.OnRaycastTovar -= OnRaise;
        Put.OnDropBox -= DropBox; // Коробку поставили
        Put.OnResetToPlayerBox -= ResetBoxToPlayer;
    }

    private void Update()
    {
        // Проверка для того чтобы бросить предмет
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTake == true)
            {
                Raise();
            }
        }
    }
    private void OnRaise(bool isRay, GameObject rayObject, string tag)
    {
        if(isRay && tag == "Box")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                raiseObject = rayObject;
                Raise();
            }
        }
    }
    
    /// <summary>
    /// Тут и обработаем логигу возвращения предмета к игроку
    /// </summary>
    private void ResetBoxToPlayer()
    {
        isTake = true;
        raiseObject.transform.parent = raisPosition;
        raiseObject.transform.position = raisPosition.transform.position;
        raiseObject.transform.rotation = raisPosition.transform.rotation;
    }
    /// <summary>
    /// Метод для бодбора и выброса предмета
    /// </summary>
    private void Raise()
    {
        isTake = !isTake;

        // Меняем настройки физики у объекта
        raiseObject.GetComponent<Rigidbody>().useGravity = !isTake;
        raiseObject.GetComponent<Rigidbody>().isKinematic = isTake;


        // И тут вся магия 
        // Проверяем что делать бросать или поднимать
        if (isTake == true)
        {
            raiseObject.transform.parent = raisPosition;
            raiseObject.transform.position = raisPosition.transform.position;
            raiseObject.transform.rotation = raisPosition.transform.rotation;
        }
        else
        {
            raiseObject.transform.parent = spawnPosition;
            raiseObject = null;
        }


        if (isTake == true)
            OnGetBox?.Invoke(raiseObject, isTake);
        else
            OnGetBox?.Invoke(null, isTake);
    }

    private void DropBox(bool take)
    {
        isTake = take;
    }
}

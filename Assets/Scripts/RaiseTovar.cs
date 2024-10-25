using UnityEngine;
using UnityEngine.UIElements;


/// <summary>
/// Скрипт отчвечает за подбор предметов
/// </summary>
public class RaiseTovar : MonoBehaviour
{
    [SerializeField]
    [Header("")]
    private Transform raisPosition;

    [SerializeField]
    [Header("")]
    private Transform spawnPosition;
    [SerializeField]
    [Header("Поднят ли предмет")]
    private bool isTake;


    private GameObject raiseObject;
    private void OnEnable()
    {
        AllRaycast.OnRaycastTovar += OnRaise;
    }

    private void OnDisable()
    {
        AllRaycast.OnRaycastTovar -= OnRaise;
    }
    private void OnRaise(bool isRay, GameObject rayObject, string tag)
    {
        if(isRay && tag == "Box")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isTake = !isTake;
                raiseObject = rayObject;

                if (isTake == true)
                {
                    raiseObject.transform.parent = raisPosition;
                    raiseObject.transform.position = raisPosition.transform.position;
                }
                else
                {
                    raiseObject.transform.parent = spawnPosition;
                }

                raiseObject.GetComponent<Rigidbody>().useGravity = !isTake;
                raiseObject.GetComponent<Rigidbody>().isKinematic = isTake;
            }
        }
    }
}

using UnityEngine;

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

                if (isTake == true)
                {
                    rayObject.transform.parent = raisPosition;
                    rayObject.transform.position = raisPosition.transform.position;
                }
                else
                {
                    rayObject.transform.parent = spawnPosition;
                }
                rayObject.GetComponent<Rigidbody>().useGravity = !isTake;
                rayObject.GetComponent<Rigidbody>().isKinematic = isTake;

                
                Debug.Log(rayObject.name);
            }
        }
    }
}

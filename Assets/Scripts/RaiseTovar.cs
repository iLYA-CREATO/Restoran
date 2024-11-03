using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


/// <summary>
/// ������ ��������� �� ������ ���������
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
    [Header("������ �� �������")]
    private bool isTake;

    [SerializeField]
    [Header("����� ������� ������")]
    private GameObject raiseObject;

    private void OnEnable()
    {
        AllRaycast.OnRaycastTovar += OnRaise;
        Put.OnDropBox += DropBox; // ������� ���������
        Put.OnResetToPlayerBox += ResetBoxToPlayer;

    }
    private void OnDisable()
    {
        AllRaycast.OnRaycastTovar -= OnRaise;
        Put.OnDropBox -= DropBox; // ������� ���������
        Put.OnResetToPlayerBox -= ResetBoxToPlayer;
    }

    private void Update()
    {
        // �������� ��� ���� ����� ������� �������
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
    /// ��� � ���������� ������ ����������� �������� � ������
    /// </summary>
    private void ResetBoxToPlayer()
    {
        isTake = true;
        raiseObject.transform.parent = raisPosition;
        raiseObject.transform.position = raisPosition.transform.position;
        raiseObject.transform.rotation = raisPosition.transform.rotation;
    }
    /// <summary>
    /// ����� ��� ������� � ������� ��������
    /// </summary>
    private void Raise()
    {
        isTake = !isTake;

        // ������ ��������� ������ � �������
        raiseObject.GetComponent<Rigidbody>().useGravity = !isTake;
        raiseObject.GetComponent<Rigidbody>().isKinematic = isTake;


        // � ��� ��� ����� 
        // ��������� ��� ������ ������� ��� ���������
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

using System;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Put : MonoBehaviour
{
    public static event Action<bool> OnDropBox;
    public static event Action OnResetToPlayerBox;

    [SerializeField]
    private GameObject raiseObject;
    [SerializeField]
    private bool isTake;
    [SerializeField]
    private bool isMove;

    [SerializeField, Header("��������� ��������� ��������")]
    private float disyanceRay;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    Vector3 pointHorizontalSurface;

    [SerializeField]
    private Material grinMaterial;
    [SerializeField]
    private Material redMaterial;

    [SerializeField]
    // ������� �������� ��������
    private Material objectMaterial;
    private void OnEnable()
    {
        RaiseTovar.OnGetBox += GetData;
    }

    private void OnDisable()
    {
        RaiseTovar.OnGetBox -= GetData;
    }


    private void FixedUpdate()
    {
        // ��� ����� ������� ������ � ������
        if (Input.GetMouseButtonDown(1) && isMove == true)
        {
            raiseObject.GetComponent<Renderer>().material = objectMaterial;
            isMove = false;

            // ��� �� ������ ��� ����� ������� ���� ������� ������� � ������ 
            // ��� �� �� ����� � �������
            // � ��������� ���������� ��� � ������ RaiseTovar
            OnResetToPlayerBox?.Invoke();
        }
        else if (Input.GetMouseButtonDown(1) && isTake == true && isMove == false)// ��� ����� ����� ��� � ������ ���
        {
            isMove = !isMove;
        }
        
        if (isMove == true)
        {
            MoveBox();
        }
        
    }
    // ��� ������ �������� ������
    private void GetData(GameObject raiseObject, bool isTake)
    {
        this.raiseObject = raiseObject;
        this.isTake = isTake;
        objectMaterial = raiseObject.GetComponent<Renderer>().material;
    }

    // ����� ��� ����������� �������
    private void MoveBox()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, disyanceRay, mask))
        {
            raiseObject.transform.rotation = Quaternion.identity;
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            pointHorizontalSurface = hit.point;
            pointHorizontalSurface.y += raiseObject.transform.localScale.y / 2;
            raiseObject.transform.position = pointHorizontalSurface;

            if (raiseObject.GetComponent<BoxTrigger>().isTrigBox == false)
            {
                raiseObject.GetComponent<Renderer>().material = grinMaterial;
                raiseObject.GetComponent<Rigidbody>().isKinematic = true;

                if (Input.GetMouseButtonDown(0) && isMove == true)
                {

                    raiseObject.GetComponent<Renderer>().material = objectMaterial;
                    raiseObject.transform.SetParent(null);

                    // ������� ������� ������ � ����� ������� ������
                    raiseObject.GetComponent<Rigidbody>().useGravity = true;
                    raiseObject.GetComponent<Rigidbody>().isKinematic = false;

                    isTake = false;
                    isMove = false;
                    raiseObject = null;
                    objectMaterial = null;
                    
                    OnDropBox?.Invoke(isTake);
                    return;
                }
            }  
            else
            {
                raiseObject.GetComponent<Renderer>().material = redMaterial;
                raiseObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else
        {
            raiseObject.GetComponent<Renderer>().material = redMaterial;
        }
    }
}

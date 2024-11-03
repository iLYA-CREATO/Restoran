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

    [SerializeField, Header("Дальность установки предмета")]
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
    // Базовый материал предмета
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
        // Тут хотим вернуть объект к игроку
        if (Input.GetMouseButtonDown(1) && isMove == true)
        {
            raiseObject.GetComponent<Renderer>().material = objectMaterial;
            isMove = false;

            // тут мы говори что хотим вернуть нашу коробку обратно к игроку 
            // Мол он не хочет её ставить
            // Я предлагаю обработать это в классе RaiseTovar
            OnResetToPlayerBox?.Invoke();
        }
        else if (Input.GetMouseButtonDown(1) && isTake == true && isMove == false)// Тут хотим взять его в первый раз
        {
            isMove = !isMove;
        }
        
        if (isMove == true)
        {
            MoveBox();
        }
        
    }
    // Тут просто получаем данные
    private void GetData(GameObject raiseObject, bool isTake)
    {
        this.raiseObject = raiseObject;
        this.isTake = isTake;
        objectMaterial = raiseObject.GetComponent<Renderer>().material;
    }

    // Метод для перемещения коробки
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

                    // Сначало очистим данные и вернём объекту физику
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

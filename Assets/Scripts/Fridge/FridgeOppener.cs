using UnityEngine;
using UnityEngine.UIElements;

public class FridgeOppener : MonoBehaviour
{
    private void OnEnable()
    {
        AllRaycast.OnRaycastAction += OpenClouse;

    }
    private void OnDisable()
    {
        AllRaycast.OnRaycastAction -= OpenClouse;
    }

    private void OpenClouse(string tag, GameObject Door)
    {
        Fridge fridge;
        if(tag == "FridgeDoor")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                fridge = Door.transform.parent.GetComponent<Fridge>();

                if(fridge.isOpenFridge == false)
                {
                    fridge.animatorFridge.Play("FridgeOpen");
                }
                else
                {
                    fridge.animatorFridge.Play("FridgeClouse");
                }

                fridge.isOpenFridge = !fridge.isOpenFridge;
            }
        }
    }
}

using UnityEngine;

public class TrashCanOppener : MonoBehaviour
{
    [SerializeField, Header("Тэг объекта")]
    private string tagObject;

    [SerializeField, Header("Менеджер кнопок")]
    private KeyManager keyManager;
    private void OnEnable()
    {
        AllRaycast.OnRaycastAction += OpenClouse;

    }
    private void OnDisable()
    {
        AllRaycast.OnRaycastAction -= OpenClouse;
    }

    private void OpenClouse(string tag, GameObject rayObject)
    {
        TrashCan trashCan;
        if (tag == tagObject)
        {
            if (Input.GetKeyDown(keyManager.PressAction))
            {
                trashCan = rayObject.transform.GetComponent<TrashCan>();

                if (trashCan.isOpenTrashCan == false)
                {
                    trashCan.animatorTrashCan.Play("TrashCanOpen");
                }
                else
                {
                    trashCan.animatorTrashCan.Play("TrashCanClouse");
                }

                trashCan.isOpenTrashCan = !trashCan.isOpenTrashCan;
            }
        }
    }
}

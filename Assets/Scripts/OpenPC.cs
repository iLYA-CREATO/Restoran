using UnityEngine;

public class OpenPC : MonoBehaviour
{
    [SerializeField]
    [Header("Менеджер кнопок")]
    private KeyManager keyManager;
    [SerializeField]
    [Header("Окно пк")]
    private GameObject PcPanel;
    [SerializeField]
    [Header("Открыт пк")]
    private bool isOpenPC;

    [SerializeField]
    [Header("Контроллер камеры")]
        private MoveCamera moveCamera;
    [SerializeField]
    [Header("Контроллер игрока")]
        private MoveCharacter moveCharacter;
    private void OnEnable()
    {
        AllRaycast.OnRaycast += RayOpenPC;
    }

    private void OnDisable()
    {
        AllRaycast.OnRaycast -= RayOpenPC;
    }

    private void RayOpenPC()
    {
        if (Input.GetKeyDown(keyManager.PressAction))
        {
            isOpenPC = true;
            PcPanel.SetActive(isOpenPC);
            
            ParametrPlayer(isOpenPC);
        }
    }
    /// <summary>
    /// Метод будет выключать окно пк
    /// </summary>
    /// Почему тут сделал реализацию, проще управлять данными
    /// и реагировать на эти изменения
    public void ClousePC()
    {
        isOpenPC = false;
        PcPanel.SetActive(isOpenPC);
       
        ParametrPlayer(isOpenPC);
    }

    /// <summary>
    /// Параметры управления игроком при открытом пк
    /// </summary>
    private void ParametrPlayer(bool isOpenPC)
    {
        if(isOpenPC)
        {
            Cursor.lockState = CursorLockMode.None;
            moveCamera.enabled = false;
            moveCharacter.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            moveCamera.enabled = true;
            moveCharacter.enabled = true;
        }

    }
}

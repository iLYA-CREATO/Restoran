using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField, Header("Менеджер кнопок")]
    private KeyManager keyManager;

    [SerializeField, Header("Меню паузы")]
    private GameObject pausePanel;

    private void LateUpdate()
    {
        if(Input.GetKeyDown(keyManager.PressePauseGame))
        {
            ActivetedPause();
        }
    }
    /// <summary>
    /// Метод можно накидывать на кнопку
    /// </summary>
    public void ActivetedPauseButton()
    {
        ActivetedPause();
    }
    /// <summary>
    /// Скрытый метод для робы из кода
    /// </summary>
    private void ActivetedPause()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        ChangeSettingPause(pausePanel.activeSelf);
    }
    /// <summary>
    /// Скрытый метод для управления настройками паузы
    /// </summary>
    /// <param name="isPause"> значение паузы</param>
    private void ChangeSettingPause(bool isPause)
    {
        switch (isPause)
        {
            case true:
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            break;

            case false:
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            break;
        }
    }
}

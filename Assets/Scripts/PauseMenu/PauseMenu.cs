using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField, Header("�������� ������")]
    private KeyManager keyManager;

    [SerializeField, Header("���� �����")]
    private GameObject pausePanel;

    private void LateUpdate()
    {
        if(Input.GetKeyDown(keyManager.PressePauseGame))
        {
            ActivetedPause();
        }
    }
    /// <summary>
    /// ����� ����� ���������� �� ������
    /// </summary>
    public void ActivetedPauseButton()
    {
        ActivetedPause();
    }
    /// <summary>
    /// ������� ����� ��� ���� �� ����
    /// </summary>
    private void ActivetedPause()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        ChangeSettingPause(pausePanel.activeSelf);
    }
    /// <summary>
    /// ������� ����� ��� ���������� ����������� �����
    /// </summary>
    /// <param name="isPause"> �������� �����</param>
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

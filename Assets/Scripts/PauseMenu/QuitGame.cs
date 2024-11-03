using UnityEngine;

public class QuitGame : MonoBehaviour
{
    /// <summary>
    /// �������� ���������� ������
    /// </summary>
    private void quitGame()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ��������� ���� � ���������
    #endif
    }

    /// <summary>
    /// ����� ��� ������ �� Unity
    /// </summary>
    public void quitGameButton()
    {
        quitGame();
    }
}

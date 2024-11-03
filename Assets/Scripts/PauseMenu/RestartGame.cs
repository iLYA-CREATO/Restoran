using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    /// <summary>
    /// �������� �������� �����
    /// </summary>
    private void RestartedGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// ����� ��� ������ � Unity
    /// </summary>
    public void RestartGameButton()
    {
        RestartedGame();
    }
}

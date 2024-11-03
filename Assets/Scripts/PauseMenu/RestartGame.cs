using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    /// <summary>
    /// Основной закрытый метод
    /// </summary>
    private void RestartedGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// Метод для рабоды в Unity
    /// </summary>
    public void RestartGameButton()
    {
        RestartedGame();
    }
}

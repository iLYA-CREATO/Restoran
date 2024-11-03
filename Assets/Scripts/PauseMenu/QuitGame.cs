using UnityEngine;

public class QuitGame : MonoBehaviour
{
    /// <summary>
    /// Закрытая реализация выхода
    /// </summary>
    private void quitGame()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Остановка игры в редакторе
    #endif
    }

    /// <summary>
    /// Метод для работы из Unity
    /// </summary>
    public void quitGameButton()
    {
        quitGame();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelManager : MonoBehaviour
{
    public void RetryGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        // Load your main menu scene (replace "MainMenu" with your actual scene name)
        SceneManager.LoadScene("MainMenu");
    }
}

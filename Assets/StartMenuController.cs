using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject quitButton;

    [Header("Settings Menu")]
    public GameObject settingsMenue;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("Win Menu")]
    public GameObject winPanel;   // ✅ Drag your WinPanel UI here in Inspector

    private bool isPaused = false;

    void Start()
    {
        

        if (settingsMenue != null) settingsMenue.SetActive(false);
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false); // hide win panel at start
    }

    void Update()
    {
        // ESC toggles pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                ShowPauseMenu();
            else
                Resume();
        }
    }

    // === Main Menu Methods ===
    public void Play()
    {
       
        SceneManager.LoadScene("UI_DuckHunt_Scene");
        Debug.Log("Player selects play to enter game");
    }

    public void Settings()
    {
        
        ToggleMainMenuButtons(false);
        if (settingsMenue != null) settingsMenue.SetActive(true);
        Debug.Log("Settings button pressed - showing Settings menu");
    }

    public void Back()
    {
        
        ToggleMainMenuButtons(true);
        if (settingsMenue != null) settingsMenue.SetActive(false);
        Debug.Log("Back button pressed - restoring main menu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }

    private void ToggleMainMenuButtons(bool state)
    {
        if (playButton != null) playButton.SetActive(state);
        if (settingsButton != null) settingsButton.SetActive(state);
        if (quitButton != null) quitButton.SetActive(state);
    }

    // === Pause Menu Methods ===
    public void ShowPauseMenu()
    {
    
        if (pauseMenu != null) pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (settingsMenue != null) settingsMenue.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
    }

    public void PauseSettings()
    {
        if (settingsMenue != null) settingsMenue.SetActive(true);
        if (pauseMenu != null) pauseMenu.SetActive(false);
    }

    public void PauseBack()
    {
        if (settingsMenue != null) settingsMenue.SetActive(false);
        if (pauseMenu != null) pauseMenu.SetActive(true);
    }

    // === Win Methods ===
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(">>> Player reached FinalGround - triggering WinPanel");
            WinGame();
        }
    }

    public void WinGame()
    {
        if (winPanel != null) winPanel.SetActive(true);

        Time.timeScale = 0f; // freeze gameplay
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject quitButton;

    [Header("Settings Menu")]
    public GameObject settingsMenue;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Panels")]
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("End Panel Buttons")]
    public GameObject retryButton;
    public GameObject mainMenuButton;

    [Header("Audio")]
    public AudioSource mainMenuMusic;
    public AudioSource endGameMusic;

    private bool isPaused = false;

    void Start()
    {
        if (settingsMenue != null) settingsMenue.SetActive(false);
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        if (retryButton != null) retryButton.SetActive(false);
        if (mainMenuButton != null) mainMenuButton.SetActive(false);

        // 🎵 Play main menu music only in Main Menu scene
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            if (mainMenuMusic != null && !mainMenuMusic.isPlaying)
            {
                mainMenuMusic.loop = true;
                mainMenuMusic.Play();
            }
        }
    }

    void Update()
    {
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
        SceneManager.LoadScene("DuckHuntFinal");
    }

    public void Settings()
    {
        ToggleMainMenuButtons(false);
        if (settingsMenue != null) settingsMenue.SetActive(true);
    }

    public void Back()
    {
        ToggleMainMenuButtons(true);
        if (settingsMenue != null) settingsMenue.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
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

    // === End Game Methods ===
    public void EndGame(bool playerWon)
    {
        if (playerWon)
        {
            ShowEndPanel(winPanel);
        }
        else
        {
            ShowEndPanel(losePanel);
        }

        // 🎶 Play end‑game music
        if (endGameMusic != null)
        {
            endGameMusic.loop = false;
            endGameMusic.Play();
        }

        // Stop main menu music if still playing
        if (mainMenuMusic != null && mainMenuMusic.isPlaying)
        {
            mainMenuMusic.Stop();
        }
    }

    private void ShowEndPanel(GameObject panel)
    {
        if (panel == null) return;

        panel.SetActive(true);

        if (retryButton != null) retryButton.SetActive(true);
        if (mainMenuButton != null) mainMenuButton.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}

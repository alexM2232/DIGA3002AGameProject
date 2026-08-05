using UnityEngine;
using UnityEngine.UI;
using TMPro;   // if you’re using TextMeshPro

public class UIManager : MonoBehaviour
{
    [Header("Round Panels")]
    public GameObject successPanel;
    public GameObject birdEscapePanel;

    [Header("End Panels")]
    public GameObject congratsPanel;
    public GameObject gameOverPanel;

    [Header("End Panel Texts")]
    public TMP_Text congratsText;   // drag your TMP_Text here
    public TMP_Text gameOverText;   // drag your TMP_Text here

    [Header("Duck Attempt Icons")]
    public Image[] duckIcons;   // assign 10 icons in Inspector
    private int currentDuckIndex = 0;

    // Show success panel briefly when duck is shot
    public void ShowRoundResult(bool success)
    {
        if (success)
        {
            successPanel.SetActive(true);
            CancelInvoke(nameof(HideRoundResult));
            Invoke(nameof(HideRoundResult), 2f);
        }
    }

    public void HideRoundResult()
    {
        successPanel.SetActive(false);
    }

    // Show escape panel briefly when duck escapes
    public void ShowBirdEscaped()
    {
        birdEscapePanel.SetActive(true);
        CancelInvoke(nameof(HideBirdEscaped));
        Invoke(nameof(HideBirdEscaped), 2f);
    }

    public void HideBirdEscaped()
    {
        birdEscapePanel.SetActive(false);
    }

    // Mark duck icons
    public void MarkDuckShot()
    {
        if (currentDuckIndex < duckIcons.Length)
        {
            duckIcons[currentDuckIndex].color = Color.red;
            currentDuckIndex++;
        }
    }

    public void MarkDuckEscaped()
    {
        if (currentDuckIndex < duckIcons.Length)
        {
            duckIcons[currentDuckIndex].color = Color.gray;
            currentDuckIndex++;
            Debug.Log("Duck shot icon set to red");
             
             duckIcons[currentDuckIndex].color = Color.red;
               currentDuckIndex++;
        }
        
    }

    // Reset panels and icons
    public void ResetPanels()
    {
        successPanel.SetActive(false);
        birdEscapePanel.SetActive(false);
        congratsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ResetDuckIcons()
    {
        currentDuckIndex = 0;
        foreach (Image icon in duckIcons)
        {
            icon.color = Color.white;
        }
    }

    // End game panels
    public void ShowCongrats()
    {
        congratsPanel.SetActive(true);
        if (congratsText != null)
        {
            congratsText.text = "Congratulations! You hit all ducks!";
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over! Some ducks escaped!";
        }
    }
    

  
}

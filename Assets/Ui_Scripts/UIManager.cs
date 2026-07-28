using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject roundResultPanel;
    public GameObject winText;
    public GameObject loseText;
    public GameObject birdEscapedPanel;

    public void ShowRoundResult(bool win)
    {
        roundResultPanel.SetActive(true);
        winText.SetActive(win);
        loseText.SetActive(!win);
    }

    public void HideRoundResult()
    {
        roundResultPanel.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    public void ShowBirdEscaped()
    {
        birdEscapedPanel.SetActive(true);
    }

    public void HideBirdEscaped()
    {
        birdEscapedPanel.SetActive(false);
    }
}



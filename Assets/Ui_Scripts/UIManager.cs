using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject successPanel;
    public GameObject birdEscapePanel;

    public void ShowRoundResult(bool success)
    {
        if (success)
        {
            successPanel.SetActive(true);
            Invoke("HideRoundResult", 1f);
        }
    }

    public void HideRoundResult()
    {
        successPanel.SetActive(false);
    }

    public void ShowBirdEscaped()
    {
        birdEscapePanel.SetActive(true);
        Invoke("HideBirdEscaped", 1f);
    }

    public void HideBirdEscaped()
    {
        birdEscapePanel.SetActive(false);
    }
}

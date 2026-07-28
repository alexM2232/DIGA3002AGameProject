using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BulletManager bulletManager;
    public DuckManager duckManager;
    public UIManager uiManager;

    public int currentRound = 1;
    public int totalRounds = 3;
    public int ducksRequiredToWin = 3;

    void Update()
    {
        // End round when bullets run out or all ducks are shot
        if (bulletManager.BulletsLeft == 0 || duckManager.DucksShot == duckManager.TotalDucks)
        {
            EndRound();
        }
    }

    void EndRound()
    {
        if (duckManager.DucksShot >= ducksRequiredToWin)
        {
            uiManager.ShowRoundResult(true); // win
        }
        else
        {
            uiManager.ShowRoundResult(false); // lose
        }

        Invoke("NextRound", 2f);
    }

    void NextRound()
    {
        currentRound++;
        if (currentRound > totalRounds)
        {
            Debug.Log("Game Over!");
        }
        else
        {
            bulletManager.ResetBullets();
            duckManager.ResetDucks();
            uiManager.HideRoundResult();
        }
    }
}

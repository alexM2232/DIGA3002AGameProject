using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public DuckSpawner duckSpawner;
    public BulletManager bulletManager;
    public DuckManager duckManager;
    public DogManager dogManager;
    public UIManager uiManager;

    [Header("Settings")]
    public int totalDucks = 10;

    private int ducksSpawned = 0;
    private bool duckActive = false;
    private bool attemptFinished = false;

    void Start()
    {
        SpawnNextDuck();
    }

    public void SpawnNextDuck()
    {
        if (ducksSpawned < totalDucks && !duckActive)
        {
            StartCoroutine(SpawnDuckWithDelay());
        }
        else if (ducksSpawned >= totalDucks)
        {
            Debug.Log("All ducks attempted!");

            // ✅ Panel fix: use StartMenuController instead of UIManager
            StartMenuController menuController = FindObjectOfType<StartMenuController>();

            if (duckManager.DucksShot == totalDucks)
            {
                menuController.EndGame(true);   // Show WinPanel
            }
            else
            {
                menuController.EndGame(false);  // Show LosePanel
            }
        }
    }

    private IEnumerator SpawnDuckWithDelay()
    {
        yield return new WaitForSeconds(2f);

        attemptFinished = false;
        duckActive = true;

        duckSpawner.SpawnSingleDuck();
        bulletManager.ResetBullets();
        uiManager.ResetPanels();

        ducksSpawned++;
    }

    public void EndDuckAttempt()
    {
        if (attemptFinished) return;
        attemptFinished = true;

        duckActive = false;
        SpawnNextDuck();
    }

    public void DuckEscaped()
    {
        if (attemptFinished) return;

        uiManager.ShowBirdEscaped();
        uiManager.MarkDuckEscaped();
        duckManager.DuckEscaped();
        dogManager.ShowDogLaugh();

        EndDuckAttempt();
    }

    public void DuckShot()
    {
        if (attemptFinished) return;

        uiManager.ShowRoundResult(true);
        uiManager.MarkDuckShot();
        duckManager.DuckShot();
        dogManager.ShowDogWithDuck();

        EndDuckAttempt();
    }
}

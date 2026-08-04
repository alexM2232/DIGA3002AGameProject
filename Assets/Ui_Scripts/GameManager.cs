using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public DuckSpawner duckSpawner;
    public BulletManager bulletManager;
    public DuckManager duckManager;
    public DogManager dogManager;

    private int ducksSpawned = 0;
    private int totalDucks = 10;
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
            // TODO: Final results panel
        }
    }

    private IEnumerator SpawnDuckWithDelay()
    {
        yield return new WaitForSeconds(2f); // breathing room
        attemptFinished = false;
        duckSpawner.SpawnSingleDuck();
        bulletManager.ResetBullets(); // reload only at start of round
        ducksSpawned++;
        duckActive = true;
    }

    public void EndDuckAttempt()
    {
        if (attemptFinished) return; // prevents duplicates
        attemptFinished = true;

        duckActive = false;
        SpawnNextDuck();
    }
}


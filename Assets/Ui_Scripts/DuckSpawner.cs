using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab;
    public Transform spawnArea;

    public void SpawnSingleDuck()
    {
        if (duckPrefab == null || spawnArea == null)
        {
            Debug.LogError("DuckSpawner is missing prefab or spawn area!");
            return;
        }

        Vector2 randomPos = new Vector2(
            Random.Range(spawnArea.position.x - 5, spawnArea.position.x + 5),
            Random.Range(spawnArea.position.y - 3, spawnArea.position.y + 3)
        );

        GameObject newDuck = Instantiate(duckPrefab, randomPos, Quaternion.identity);
        Debug.Log("Duck spawned at: " + randomPos);
    }
}

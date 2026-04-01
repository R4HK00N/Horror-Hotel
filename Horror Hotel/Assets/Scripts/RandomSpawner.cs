using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] Transform[] enemySpawnPoints;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] GameObject[] alwaysOnItems;   // always turned on
    [SerializeField] GameObject[] randomItems;     // pool of possible extras
    [SerializeField] int extraToSpawn = 2;

    void Start()
    {
        // Random enemy spawn (once)
        if (enemySpawnPoints.Length > 0 && enemyPrefab != null)
        {
            Transform spawn = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
            Instantiate(enemyPrefab, spawn.position, spawn.rotation);
        }

        // Always on items
        foreach (var item in alwaysOnItems)
            if (item) item.SetActive(true);

        // Extra random items
        for (int i = 0; i < extraToSpawn && randomItems.Length > 0; i++)
        {
            int r = Random.Range(0, randomItems.Length);
            if (randomItems[r]) randomItems[r].SetActive(true);
        }
    }
}
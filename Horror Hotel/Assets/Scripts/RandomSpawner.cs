using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;      // 5 different spawn points
    [SerializeField] GameObject[] randomImages;    // Images / objects to randomly turn on

    [SerializeField] int imagesToActivate = 2;     // How many random images to turn on

    void Start()
    {
        // Random spawn for one object (e.g. key, item, etc.)
        if (spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            // Example: spawn something here if needed
            Debug.Log("Random spawn at point: " + randomIndex);
        }

        // Turn on random images
        for (int i = 0; i < imagesToActivate && randomImages.Length > 0; i++)
        {
            int r = Random.Range(0, randomImages.Length);
            if (randomImages[r] != null)
            {
                randomImages[r].SetActive(true);
            }
        }
    }
}
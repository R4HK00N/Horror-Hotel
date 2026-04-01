using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int itemsToCollect = 3;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawnPoint;
    [SerializeField] Collider startDoor;

    public static int collected = 0;
    public static bool hasKey = false;
    public static bool hasOpenedExitDoor = false;   // New bool for exit door

    public static GameManager instance;

    void Awake()
    {
        instance = this;
        collected = 0;
        hasKey = false;
        hasOpenedExitDoor = false;
    }

    void Start()
    {
        if (startDoor != null)
        {
            if (startDoor is BoxCollider || startDoor is SphereCollider || startDoor is CapsuleCollider)
                startDoor.isTrigger = true;
        }
    }

    public void CollectItem()
    {
        collected++;
        if (collected >= itemsToCollect)
        {
            Debug.Log("You Win! All items collected.");
            Time.timeScale = 0f;
        }
    }

    public void PickupKey()
    {
        hasKey = true;
        Debug.Log("Key picked up!");
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Enemy caught you.");
        Time.timeScale = 0f;
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab != null && enemySpawnPoint != null)
        {
            Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        }
    }

    // Called when player interacts with Exit Door
    public void OpenExitDoor()
    {
        hasOpenedExitDoor = true;
        if (hasKey)
        {
            Debug.Log("WIN GAME! You escaped with the key.");
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("You need the key to open this door.");
        }
    }
}
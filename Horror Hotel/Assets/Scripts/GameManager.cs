using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int itemsToCollect = 3;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawnPoint;
    [SerializeField] Collider startDoor;

    public static int collected = 0;
    public static bool hasKey = false;        // Key status
    public static GameManager instance;

    void Awake()
    {
        instance = this;
        collected = 0;
        hasKey = false;
    }

    void Start()
    {
        if (startDoor != null)
        {
            if (startDoor is BoxCollider || startDoor is SphereCollider || startDoor is CapsuleCollider)
            {
                startDoor.isTrigger = true;
            }
            else
            {
                Debug.LogWarning("StartDoor should use BoxCollider for trigger.");
            }
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

    // New: Called when picking up key
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

    // Door trigger - now checks for key
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If this is the start door
            if (startDoor != null && other == startDoor)
            {
                SpawnEnemy();
                startDoor.enabled = false;
            }
            // If this is the exit door (win door)
            else if (hasKey)
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
}
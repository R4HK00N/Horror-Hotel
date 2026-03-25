using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int itemsToCollect = 3;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawnPoint;
    [SerializeField] Collider startDoor;

    public static int collected = 0;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
        collected = 0;
    }

    void Start()
    {
        // Fix: Only set Is Trigger if it's a BoxCollider or simple collider
        if (startDoor != null)
        {
            if (startDoor is BoxCollider || startDoor is SphereCollider || startDoor is CapsuleCollider)
            {
                startDoor.isTrigger = true;
            }
            else
            {
                Debug.LogWarning("StartDoor has a MeshCollider. Change it to BoxCollider or add a separate trigger.");
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemy();
            if (startDoor != null) startDoor.enabled = false;
        }
    }
}
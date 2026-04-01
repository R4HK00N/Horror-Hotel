using UnityEngine;

public class JumpScare : MonoBehaviour
{
    [SerializeField] GameObject hiddenEnemy;   // The second enemy that appears (initially disabled)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hiddenEnemy != null)
            {
                hiddenEnemy.SetActive(true);   // Show the jump scare enemy
            }
        }
    }
}
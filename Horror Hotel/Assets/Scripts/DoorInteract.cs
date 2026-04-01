using UnityEngine;

public class DoorInteract : Interactable
{
    [SerializeField] GameManager gameManager;   // Drag GameManager here

    public override void OnInteract()
    {
        base.OnInteract();
        if (gameManager != null)
        {
            gameManager.OpenExitDoor();
        }
    }
}
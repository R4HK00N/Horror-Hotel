using UnityEngine;

public class StartDoor : Interactable
{
    [SerializeField] Animator animator;
    [SerializeField] GameManager gameManager;
    public override void OnInteract()
    {
        base.OnInteract();

        animator.SetInteger("DoorState", 1);
    }
}

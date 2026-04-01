using UnityEngine;

public class StartDoor : Interactable
{
    [SerializeField] Animator animator;
    public override void OnInteract()
    {
        base.OnInteract();

        animator.SetInteger("DoorState", 1);
    }
}

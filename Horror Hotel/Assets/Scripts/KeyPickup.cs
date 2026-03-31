using UnityEngine;

public class KeyPickup : Interactable
{
   
    public override void OnInteract()
    {
        base.OnInteract();
        GameManager.instance.PickupKey();
        Destroy(gameObject);

    }
}
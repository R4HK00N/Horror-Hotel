using UnityEngine;

public class SecondFloorTP : Interactable
{
    public Transform player;
    public Transform tpEmpty;
    public override void OnInteract()
    {
        base.OnInteract();
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        player.position = tpEmpty.position;
        if (cc != null) cc.enabled = true;
        print("tp");
    }
}

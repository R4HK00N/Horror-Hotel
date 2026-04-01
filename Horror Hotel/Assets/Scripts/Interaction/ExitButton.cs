using UnityEngine;

public class ExitButton : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();
        Application.Quit();
    }
}

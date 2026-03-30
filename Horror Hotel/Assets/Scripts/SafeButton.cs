using UnityEngine;

public class SafeButton : Interactable
{
    [SerializeField] string digit;          
    [SerializeField] Safe safe;            
    public override void OnInteract()
    {
        base.OnInteract();

        print(digit);

        if (safe != null)
            safe.PressButton(digit);
    }
}
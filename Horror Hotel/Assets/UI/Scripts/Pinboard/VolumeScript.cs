using UnityEngine;

public class VolumeScript : Interactable
{
    [SerializeField] bool decreaseButton;
    [SerializeField] bool increaseButton;

    [SerializeField] VolumeHandler volumehandler;

    public override void OnInteract()
    {
        base.OnInteract();

        //print("interaction");
        if (decreaseButton)
        {
            volumehandler.DecreaseVolume();
        }
        if (increaseButton)
        {
            volumehandler.IncreaseVolume();
        }
    }
}

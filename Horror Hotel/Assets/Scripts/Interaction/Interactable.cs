using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnInteract()
    {
        Debug.Log("Clicked once");
    }

    public virtual void OnInteractEnd()
    {
        Debug.Log("ending click");
    }
}
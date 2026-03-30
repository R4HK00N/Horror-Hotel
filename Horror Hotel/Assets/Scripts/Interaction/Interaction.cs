using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] float interactionDistance;

    void Update()
    {
        // Single click (mouse press)
        if (Input.GetMouseButtonDown(0))
        {
            TryInteract(false);
        }

        // End click (mouse release)
        if (Input.GetMouseButtonUp(0))
        {
            TryInteract(true);
        }
    }

    void TryInteract(bool isEndClick)
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (isEndClick)
                    interactable.OnInteractEnd();    // Trigger on mouse release
                else
                    interactable.OnInteract();    // Trigger on mouse press
            }
        }
    }
}
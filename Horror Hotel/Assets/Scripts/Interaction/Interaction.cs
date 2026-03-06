using Unity.Burst.CompilerServices;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] float interactionDistance;
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, interactionDistance))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                print(hit.collider.gameObject.name);

                if (interactable != null)
                {
                    interactable.OnInteract();
                }
            }
        }
    }
}
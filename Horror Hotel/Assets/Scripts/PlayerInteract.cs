using UnityEngine;

public class SimplePickup : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform holdPoint;
    [SerializeField] float distance = 3f;
    [SerializeField] LayerMask layer = -1;

    GameObject heldItem;

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }

    void Update()
    {
        if (heldItem != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();
            }
            return;
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distance, layer))
        {
            if (hit.collider.CompareTag("Pickup") && Input.GetKeyDown(KeyCode.E))
            {
                Pickup(hit);
            }
        }
    }

    void Pickup(RaycastHit hit)
    {
        heldItem = hit.collider.gameObject;
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        Collider col = heldItem.GetComponent<Collider>();
        if (rb) rb.isKinematic = true;
        if (col) col.enabled = false;
        heldItem.transform.SetParent(holdPoint);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;
    }

    void Drop()
    {
        if (heldItem == null) return;
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        Collider col = heldItem.GetComponent<Collider>();
        if (rb) rb.isKinematic = false;
        if (col) col.enabled = true;
        heldItem.transform.SetParent(null);
        heldItem = null;
    }
}
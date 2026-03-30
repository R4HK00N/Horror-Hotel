using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class DraggableDoor : Interactable
{
    [Header("Door Settings")]
    public float rotationSpeed = 5f;       // How fast the door follows the mouse
    public float maxAngle = 120f;          // Maximum hinge angle (degrees)
    public float minAngle = 0f;            // Minimum hinge angle (degrees)

    private bool isInteracting = false;
    private float lastMouseX;

    private HingeJoint hinge;
    private Rigidbody rb;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();

        // Set up hinge joint limits
        hinge.useLimits = true;
        JointLimits limits = hinge.limits;
        limits.min = minAngle;
        limits.max = maxAngle;
        hinge.limits = limits;

        hinge.useMotor = false;
    }

    void FixedUpdate()
    {
        if (isInteracting)
        {
            DragDoorDirect();
        }
    }

    public override void OnInteract()
    {
        // Called when player starts grabbing the door (e.g., mouse down)
        isInteracting = true;
        lastMouseX = Input.mousePosition.x;
        hinge.useMotor = false; // Disable any automated motor
        rb.angularVelocity = Vector3.zero; // Stop any ongoing rotation
        rb.isKinematic = false; // Ensure physics is enabled
    }

    public override void OnInteractEnd()
    {
        // Called when player releases the door (e.g., mouse up)
        isInteracting = false;
        rb.angularVelocity = Vector3.zero; // Stop door movement
    }

    /// <summary>
    /// Directly rotates the door based on mouse movement, simulating hand-driven interaction.
    /// This method maps horizontal mouse movement to the hinge's angle in real time.
    /// </summary>
    private void DragDoorDirect()
    {
        float mouseX = Input.mousePosition.x;
        float deltaX = mouseX - lastMouseX;
        lastMouseX = mouseX;

        // Convert mouse movement to angle delta (tweak rotationSpeed for feel)
        float angleDelta = deltaX * rotationSpeed * Time.fixedDeltaTime;

        // Get current hinge angle (in degrees)
        float currentAngle = hinge.angle;

        // Calculate new target angle and clamp within limits
        float targetAngle = Mathf.Clamp(currentAngle + angleDelta, minAngle, maxAngle);

        // Calculate the absolute world axis for the hinge
        Vector3 worldAxis = transform.TransformDirection(hinge.axis);

        // Calculate the rotation difference needed
        float angleToRotate = targetAngle - currentAngle;

        // Apply the rotation directly to the Rigidbody using MoveRotation for smooth, physics-respecting movement
        Quaternion deltaRotation = Quaternion.AngleAxis(angleToRotate, worldAxis);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Note: This approach gives the player direct, responsive control over the door,
        // as if they are physically rotating it with their hand.
    }

    // Optional mouse support for editor/testing
    private void OnMouseDown()
    {
        OnInteract();
    }

    private void OnMouseUp()
    {
        OnInteractEnd();
    }
}
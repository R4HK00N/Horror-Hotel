using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Playercontroller : MonoBehaviour
{
    float speed;
    private Rigidbody rb;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    [Header("stamina")]
    [SerializeField] float runMultiplier;
    [SerializeField] float maxStamina;
    [SerializeField] float regenRate;

    private float currentStamina;
    bool isRunning;

    private void Start()
    {
        speed = walkSpeed;
        currentStamina = maxStamina;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // prevent tipping over
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;

        rb.linearVelocity = transform.TransformDirection(moveDir) * speed + new Vector3(0f, rb.linearVelocity.y, 0f);

        Stamina();
    }
    void Stamina()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f;
        if (isRunning)
        {
            currentStamina -= regenRate * Time.deltaTime;
            speed = runSpeed;

            if (currentStamina < 0f)
            {
                currentStamina = 0f;
            }
        }
        else if (currentStamina < maxStamina)
        {
            currentStamina += regenRate * Time.deltaTime;
            speed = walkSpeed;

            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }
    }
}
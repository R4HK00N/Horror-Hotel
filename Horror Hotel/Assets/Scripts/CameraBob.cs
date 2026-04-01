using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [SerializeField] float bobIntensity = 0.05f;     // up/down
    [SerializeField] float weaveIntensity = 0.03f;   // left/right
    [SerializeField] float swayIntensity = 0.02f;    // new: forward/back sway
    [SerializeField] float bobSpeed = 10f;

    Vector3 startPos;
    float timer = 0f;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
            timer += Time.deltaTime * bobSpeed;

            float bob = Mathf.Sin(timer) * bobIntensity;
            float weave = Mathf.Sin(timer * 0.5f) * weaveIntensity;
            float sway = Mathf.Sin(timer * 0.7f) * swayIntensity;   // forward/back sway

            transform.localPosition = startPos + new Vector3(weave, bob, sway);
        }
        else
        {
            timer = 0f;
            transform.localPosition = startPos;
        }
    }
}
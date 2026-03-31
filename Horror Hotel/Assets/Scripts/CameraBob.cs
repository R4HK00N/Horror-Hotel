using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [SerializeField] float bobIntensity = 0.05f;     // vertical bob strength
    [SerializeField] float weaveIntensity = 0.03f;   // side-to-side weaving strength
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
            float weave = Mathf.Sin(timer * 0.5f) * weaveIntensity;   // slower side weave

            transform.localPosition = startPos + new Vector3(weave, bob, 0);
        }
        else
        {
            timer = 0f;
            transform.localPosition = startPos;
        }
    }
}
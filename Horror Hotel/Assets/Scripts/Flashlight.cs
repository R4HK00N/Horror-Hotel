using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Light flashlight;
    [SerializeField] float maxBattery;
    [SerializeField] float batteryIncrease;
    [SerializeField] float batteryDecrease;
    [SerializeField] float cooldownTime;

    [Header("test")]
    [SerializeField] TMP_Text testBatteryText;

    float currentBattery;
    float currentCooldown;
    bool isOn = false;
    bool batteryFull = true;
    bool onCooldown = false;

    private void Start()
    {
        currentBattery = maxBattery;
        currentCooldown = cooldownTime;
        flashlight.enabled = isOn;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && flashlight && !onCooldown)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
            onCooldown = true;
        }
        if (onCooldown)
        {
            FlashlightCooldown();
        }
        FlashlightBattery();

        if(testBatteryText != null)
            testBatteryText.text = currentBattery.ToString("N0");
    }
    void FlashlightBattery()
    {
        if (isOn)
        {
            if (currentBattery >= 0)
            {
                currentBattery -= batteryDecrease * Time.deltaTime;
            }
            else
            {
                isOn = false;
                flashlight.enabled = isOn;
            }
        }
        if (!isOn)
        {
            if (currentBattery < maxBattery)
            {
                currentBattery += batteryIncrease * Time.deltaTime;
            }
        }
    }
    void FlashlightCooldown()
    {
        if(currentCooldown > 0)
        {
            print("onCooldown");
            currentCooldown -= cooldownTime * Time.deltaTime;
        }
        else
        {
            onCooldown = false;
            currentCooldown = cooldownTime;
        }
    }
}
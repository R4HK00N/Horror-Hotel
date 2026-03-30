using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] string correctCode = "4729";

    private string enteredCode = "";

    public void PressButton(string digit)
    {
        if (enteredCode.Length >= 4) return;

        enteredCode += digit;
        Debug.Log("Pressed: " + digit + " | Current code: " + enteredCode);
    }

    public void TryOpen()
    {
        Debug.Log("Trying code: " + enteredCode);
        if (enteredCode == correctCode)
        {
            Debug.Log("Correct! Safe Opened!");
        }
        else
        {
            Debug.Log("Wrong Code");
            ClearCode();
        }
    }

    public void ClearCode()
    {
        enteredCode = "";
        Debug.Log("Code Cleared");
    }
}
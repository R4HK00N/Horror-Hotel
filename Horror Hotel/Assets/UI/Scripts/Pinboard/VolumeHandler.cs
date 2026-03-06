using UnityEngine;

public class VolumeHandler : MonoBehaviour
{
    [SerializeField] int currentBars;

    [SerializeField] GameObject[] volumeBars;
    private void Start()
    {
        currentBars = PlayerPrefs.GetInt("barAmount");

        UpdateBars();
    }
    public void DecreaseVolume()
    {
        if (currentBars > 0)
        {
            currentBars--;
            UpdateBars();

            PlayerPrefs.SetInt("barAmount", currentBars);
        }
    }
    public void IncreaseVolume()
    {
        if (currentBars < volumeBars.Length)
        {
            currentBars++;
            UpdateBars();

            PlayerPrefs.SetInt("barAmount", currentBars);
        }
    }
    void UpdateBars()
    {
        for (int i = 0; i < volumeBars.Length; i++)
        {
            volumeBars[i].SetActive(i < currentBars);
        }
    }
}

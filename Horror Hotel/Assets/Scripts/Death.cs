using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject[] skulls;
    int currentLives = 3;
    private void Start()
    {
        currentLives = PlayerPrefs.GetInt("Lives");
    }
    public void DoDeathScene()
    {
        deathScreen.SetActive(true);

        StartCoroutine(WaitForSkull(3f));
    }
    IEnumerator WaitForSkull(float time)
    {
        yield return new WaitForSeconds(time);
        skulls[currentLives].SetActive(false);

        StartCoroutine(WaitforReload(3f));
    }
    IEnumerator WaitforReload(float time)
    {
        yield return new WaitForSeconds(time);
        PlayerPrefs.SetInt("Lives", currentLives - 1);
        if(currentLives != 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        else
        {
            PlayerPrefs.SetInt("Lives", 3);
            Application.Quit();
        }
    }
}

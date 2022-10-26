using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void goStart()
    {
        SceneManager.LoadScene("start");
    }

    public void goFinalBoss()
    {
        SceneManager.LoadScene("finalBoss");
    }

    public void goTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void QuitFromMain()
    {
        // Only with compiled version
        Application.Quit();
    }
}

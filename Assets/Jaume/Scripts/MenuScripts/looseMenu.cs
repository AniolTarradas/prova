using UnityEngine;
using UnityEngine.SceneManagement;

public class looseMenu : MonoBehaviour
{
    public void goReStart()
    {
        SceneManager.LoadScene("start");
    }

    public void goMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}


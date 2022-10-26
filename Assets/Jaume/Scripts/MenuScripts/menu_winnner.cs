using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_winnner : MonoBehaviour
{
    public void goPlayAgain()
    {
        SceneManager.LoadScene("start");
    }

    public void goMainMenuFromWinner()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void goFinish()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
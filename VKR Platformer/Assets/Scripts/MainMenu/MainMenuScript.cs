using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("ThirdLevel");
    }
}

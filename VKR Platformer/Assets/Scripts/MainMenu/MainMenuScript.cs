using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private GameObject webManager;
    private WebManager webManagerScript;

    private void Start()
    {
        webManager = GameObject.Find("WebManager");
        webManagerScript = webManager.GetComponent<WebManager>();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void LoadAchievement()
    {
        SceneManager.LoadScene("Achievement");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void QuitGame()
    {
        webManagerScript.Save();
        Debug.Log("QUIT");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool paused = false;

    [SerializeField] private GameObject pauseMenu;

    PauseAction action;

    private void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    public void DeterminePause()
    {
        if (paused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        pauseMenu.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        pauseMenu.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.Find("GameManager(Clone)"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        paused = false;
        AudioListener.pause = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.Find("GameManager(Clone)"));
        SceneManager.LoadScene("MainMenu");
    }
}

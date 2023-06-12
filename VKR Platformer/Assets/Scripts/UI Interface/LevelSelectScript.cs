using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    private Button[] levelButtons;

    private int levelCount;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        CheckSaveData();

        levelButtons = GameObject.Find("LevelButtons").GetComponentsInChildren<Button>();

        levelCount = PlayerPrefs.GetInt("Available_levels");

        for (int i = 0; i < levelCount; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void CheckSaveData()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        PlayerPrefs.SetFloat("StartGameTime", Time.time);
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
    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}

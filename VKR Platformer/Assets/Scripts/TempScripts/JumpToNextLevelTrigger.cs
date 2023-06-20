using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;

public class JumpToNextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GameObject.FindGameObjectWithTag("Enemy"))
        {
            PlayerPrefs.SetFloat("LevelTime" + (SceneManager.GetActiveScene().buildIndex - 3), Time.time - PlayerPrefs.GetFloat("StartGameTime"));

            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                PlayerPrefs.SetInt("You are a winner", 1);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Destroy(GameObject.Find("GameManager(Clone)"));

                Debug.Log(PlayerPrefs.GetFloat("LevelTime1") + PlayerPrefs.GetFloat("LevelTime2") + PlayerPrefs.GetFloat("LevelTime3"));

                if(PlayerPrefs.GetFloat("LevelTime1") + PlayerPrefs.GetFloat("LevelTime2") + PlayerPrefs.GetFloat("LevelTime3") <= 1000.0f)
                {
                    PlayerPrefs.SetInt("Speedrun", 1);
                }
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                PlayerPrefs.SetInt("Available_levels", SceneManager.GetActiveScene().buildIndex - 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            Debug.Log("Kill all enemies");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class SetAchievementScript : MonoBehaviour
{
    [SerializeField] protected string[] arrayTitles;
    [SerializeField] protected string[] arrayDescription;
    [SerializeField] protected Sprite[] arraySprite;
    [SerializeField] protected GameObject achievement;
    [SerializeField] protected GameObject content;

    protected List<GameObject> list = new List<GameObject>();

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        SetAchievements();
    }

    private void RemoveList()
    {
        foreach (var item in list)
        {
            Destroy(item);
        }
        list.Clear();
    }

    public void SetAchievements()
    {
        RemoveList();

        for (int i = 0; i < arrayTitles.Length; i++)
        {
            GameObject achiv = Instantiate(achievement, transform);

            Image[] titles = achiv.GetComponentsInChildren<Image>();

            TMP_Text[] descriptions = titles[0].GetComponentsInChildren<TMP_Text>();
            
            titles[1].GetComponent<Image>().sprite = arraySprite[0];

            descriptions[0].GetComponent<TMP_Text>().text = arrayDescription[i];
            descriptions[1].GetComponent<TMP_Text>().text = arrayTitles[i];

            switch (i)
            {
                case 0: // You are a winner
                    if (PlayerPrefs.GetInt(arrayTitles[i]) == 1)
                    {
                        titles[1].GetComponent<Image>().sprite = arraySprite[1];
                    }
                    break;
                case 1: // Untouchable
                    if (PlayerPrefs.GetInt(arrayTitles[i]) == 1 && PlayerPrefs.GetInt("You are a winner") == 1)
                    {
                        titles[1].GetComponent<Image>().sprite = arraySprite[1];
                    }
                    break;
                case 2: // Immortal knight
                    if(PlayerPrefs.GetInt(arrayTitles[i]) == 0 && PlayerPrefs.GetInt("You are a winner") == 1)
                    {
                        titles[1].GetComponent<Image>().sprite = arraySprite[1];
                    }
                    break;
                case 3: // First blood
                    if (PlayerPrefs.GetInt(arrayTitles[i]) == 1)
                    {
                        titles[1].GetComponent<Image>().sprite = arraySprite[1];
                    }
                    break;
                case 4: // Speedrun
                    if (PlayerPrefs.GetInt(arrayTitles[i]) == 1 && PlayerPrefs.GetInt("You are a winner") == 1)
                    {
                        titles[1].GetComponent<Image>().sprite = arraySprite[1];
                    }
                    break;
                case 5: // First block
                    if(PlayerPrefs.GetInt(arrayTitles[i]) == 1)
                    {
                        titles[1].GetComponent<Image>().sprite = arraySprite[1];
                    }
                    break;
            }

            /*if (PlayerPrefs.GetInt(arrayTitles[i], 0) == 1)
            {
                titles[0].GetComponent<Image>().sprite = arraySprite[1];
            }
            else
            {
                titles[0].GetComponent<Image>().sprite = arraySprite[0];
            }*/

            list.Add(achiv);
        }
    }
    public void ResetAchievement()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Achievement");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetCharactersScript : MonoBehaviour
{
    private GameObject content;

    private AudioSource audioSource;

    private void Start()
    {
        content = GameObject.Find("Descriptions");
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    public void ButtonClick()
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            content.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        for (int i = 0; i < content.transform.childCount; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == content.transform.GetChild(i).name)
            {
                content.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    public void Back()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}

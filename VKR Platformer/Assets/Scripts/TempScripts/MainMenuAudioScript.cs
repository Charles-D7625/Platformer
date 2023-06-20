using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioScript : MonoBehaviour
{
    public static MainMenuAudioScript Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

    }
}

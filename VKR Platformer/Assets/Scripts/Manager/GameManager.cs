using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float startGame;

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

    private void Start()
    {
        startGame = Time.time;
    }
}

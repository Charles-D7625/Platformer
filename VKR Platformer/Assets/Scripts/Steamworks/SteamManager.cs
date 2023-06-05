using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamManager : MonoBehaviour
{
    public static SteamManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            try
            {
                SteamClient.Init(480);
                Debug.Log("Steam is running");
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }

            DontDestroyOnLoad(this);
            Instance = this;
        }

        
    }

    private void Update()
    {
        SteamClient.RunCallbacks();
    }

    private void OnApplicationQuit()
    {
        try
        {
            SteamClient.Shutdown();
        }
        catch
        {

        }
    }
}

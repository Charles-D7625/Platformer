using Cinemachine;
using Newtonsoft.Json;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UserData
{
    public PlayerSteamData playerSteamData;
    public Error error;
}

[System.Serializable]
public class Error
{
    public string errorText;
    public bool isError;
}

[System.Serializable]
public class PlayerSteamData
{
    public int id;
    public string userAchievements;
    public int avaliableLevels;

    public PlayerSteamData(string userAchievements, int avaliableLevels)
    {
        this.userAchievements = userAchievements;
        this.avaliableLevels = avaliableLevels;
    }

}

public class WebManager : MonoBehaviour
{
    public static WebManager Instance;

    public string targetURL = "http://localhost:8080/gamedata/login.php";

    public UserData userData = new UserData();

    public static string[] achievements = {"You are a winner", "Untouchable", "Immortal knight", "First blood", "Speedrun", "First block"};

    public List<string> userAchievementTemp;
    public string GetUserData(UserData userDataFromBase)
    {
        return JsonUtility.ToJson(userDataFromBase);
    }

    public UserData SetUserData(string userDataFromBase)
    {
        return JsonUtility.FromJson<UserData>(userDataFromBase);
    }

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
            Login();
        }
    }

    

    private void Start()
    {
        if (userData.playerSteamData.avaliableLevels <= 1)
        {
            PlayerPrefs.SetInt("Available_levels", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Available_levels", userData.playerSteamData.avaliableLevels);
        }

        Debug.Log(userData.playerSteamData.userAchievements);

        if (userData.playerSteamData.userAchievements.Length == 0)
        {
            for (int i = 0; i < achievements.Length; i++)
            {
                userData.playerSteamData.userAchievements = "000000";
                PlayerPrefs.SetInt(achievements[i], 0);
            }
        }
        else
        {
            for (int i = 0; i < userData.playerSteamData.userAchievements.Length; i++)
            {

                PlayerPrefs.SetInt(achievements[i], int.Parse(userData.playerSteamData.userAchievements[i].ToString()));

            }
        }
    }


    public void Login() 
    {
        StopAllCoroutines();
        WWWForm form = new WWWForm();

        form.AddField("type", "logging");
        form.AddField("login", SteamClient.SteamId.ToString());
        StartCoroutine(SendData(form, "logging"));
    }

    public void Save()
    {
        string temp = "";

        for (int i = 0; i < userData.playerSteamData.userAchievements.Length; i++)
        {
            userAchievementTemp.Add(PlayerPrefs.GetInt(achievements[i]).ToString());
        }

        Debug.Log(userAchievementTemp.Count);

        for (int i = 0; i < userAchievementTemp.Count; i++)
        {
            temp = temp.Insert(temp.Length, userAchievementTemp[i]);
        }
        
        Debug.Log(temp);

        StopAllCoroutines();
        WWWForm form = new WWWForm();

        form.AddField("type", "save");

        form.AddField("id", userData.playerSteamData.id);

        form.AddField("userAchievements", temp);

        form.AddField("avaliableLevels", PlayerPrefs.GetInt("Available_levels"));

        StartCoroutine(SendData(form, "save"));
    }

    IEnumerator SendData(WWWForm form, string type)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(targetURL, form))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                
            }
            else
            {
                //Debug.Log("1 : " + GetUserData(userData));
                //Debug.Log("2 : " + www.downloadHandler.text);
                userData = SetUserData(www.downloadHandler.text);
                //Debug.Log("3 : " + GetUserData(userData));
            }
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
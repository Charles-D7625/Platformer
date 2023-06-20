using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager GM;

    private CinemachineVirtualCamera CVC;

    private void Start()
    {
        if (!GameObject.FindWithTag("Respawn"))
        {
            Instantiate(GM);
        }

        if (!GameObject.FindWithTag("Player"))
        {
            var playerTemo = Instantiate(player, gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            CVC.m_Follow = playerTemo.transform;
            DontDestroyOnLoad(playerTemo);
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();

        if (GameObject.FindWithTag("Player"))
        {
            CVC.m_Follow = GameObject.FindWithTag("Player").transform;

            GameObject.FindWithTag("Player").transform.position = gameObject.transform.position;
            
        }
    }
}

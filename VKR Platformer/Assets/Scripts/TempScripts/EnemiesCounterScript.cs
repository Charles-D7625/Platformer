using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCounterScript : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesCounter;

    private void Update()
    {
        enemiesCounter.text = "Enemies left: " + GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}

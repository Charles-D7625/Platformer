using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    private Stats stats;

    private void Update()
    {
        CheckPlayer();
    }

    public void CheckPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            stats = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Stats>();
            slider.value = stats.currentHealth;
            fill.color = gradient.Evaluate(stats.currentHealth / 100);
        }
        else
        {
            Debug.Log("Player not exist");
        }
    }
}

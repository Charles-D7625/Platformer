using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    private void Update()
    {
        slider.value = stats.currentHealth;
        fill.color = gradient.Evaluate(stats.currentHealth / 100);
    }
}

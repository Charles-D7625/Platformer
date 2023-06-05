using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] private float maxHealth;
    [SerializeField] private float deadAnimDuration;

    private float lastHitTime;

    public float currentHealth { get; private set; }
    
    public bool isHitActive;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
    }

    public override void LogicUpdate()
    {
        if (currentHealth <= 0 && Time.time >= lastHitTime + deadAnimDuration)
        {
            currentHealth = 0;

            OnHealthZero?.Invoke();

            if (core.transform.parent.tag == "Player")
            {
                PlayerPrefs.SetInt("Immortal knight", 0);
                Destroy(GameObject.Find("GameManager(Clone)"));
                SceneManager.LoadScene("MainMenu");
            }

            if(core.transform.parent.tag == "Enemy")
            {
                PlayerPrefs.SetInt("First blood", 1);
            }
        }
    }

    public void DecreaseHealth(float amount)
    {
        isHitActive = true;
        currentHealth -= amount;
        lastHitTime = Time.time;
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}

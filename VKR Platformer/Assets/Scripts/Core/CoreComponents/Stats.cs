using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

            Debug.Log("Health " + currentHealth);
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

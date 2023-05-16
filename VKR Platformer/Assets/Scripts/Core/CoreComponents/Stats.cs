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

    public float currentHealth { get; private set; }

    public bool isHitActive;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        isHitActive = true;
        currentHealth -= amount;

        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            OnHealthZero?.Invoke();

            Debug.Log("Health " + currentHealth);
            //Add dead anim for each object
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}

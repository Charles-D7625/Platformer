using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, knockbackSpeedX, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY;
    [SerializeField]
    private bool applyKnockback;

    private int playerFacingDiraction;

    private float currentHealth, knockbackStart;

    private bool knockback;

    private PlayerController pc;
    private GameObject aliveGO, deadGO;
    private Rigidbody2D rbAlive, rbDead;
    private Animator aliveAnim;

    private void Start()
    {
        currentHealth = maxHealth;

        pc = GameObject.Find("Player").GetComponent <PlayerController>();

        aliveGO = transform.Find("Alive").gameObject;
        deadGO = transform.Find("Dead").gameObject;

        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent <Rigidbody2D>();
        rbDead = deadGO.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);
        deadGO.SetActive(false);
    }

    private void Update()
    {
        CheckKnockback();
    }

    private void Damage(float amount)
    {
        currentHealth -= amount;
        playerFacingDiraction = pc.GetFacingDirection();
        aliveAnim.SetTrigger("Damage");

        if(applyKnockback && currentHealth > 0.0f)
        {
            Knockback();
        }

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;
        rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDiraction, knockbackSpeedY);
    }

    private void CheckKnockback()
    {
        if(Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y);
        }
    }

    private void Die()
    {
        aliveGO.SetActive(false);
        deadGO.SetActive(true);

        deadGO.transform.position = aliveGO.transform.position;

        rbDead.velocity = new Vector2(knockbackDeathSpeedX * playerFacingDiraction, knockbackDeathSpeedY);

    }
}

using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    /*[SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private float stunDamageAmount = 1.0f;
    [SerializeField]
    private Transform attack1HitBoxPosition;
    [SerializeField]
    private LayerMask whatIsDamageable;


    private bool gotLeftInput;
    private bool gotRightInput;
    private bool parryEnabled;
    private bool isAttacking;
    private bool isFirstAttack;
    private bool isSecondAttack;
    private bool isThirdAttack;

    public bool isOnParryState;

    private AttackDetails attackDetails;

    private float lastInputTime = Mathf.NegativeInfinity;
    private float lastInputRightButtonTime = Mathf.NegativeInfinity;
    private float parryWindow = 0.4f;

    private Animator anim;

    private PlayerController pc;
    private PlayerStats ps;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("CanAttack", combatEnabled);
        pc = GetComponent<PlayerController>();
        ps = GetComponent<PlayerStats>();

        parryEnabled = true;
        isOnParryState = false;
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
        CheckParryInput();
        CheckParry();
    }

    private void CheckCombatInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(combatEnabled && !isOnParryState) 
            {
                gotLeftInput = true;
                lastInputTime= Time.time;
            }
        }
    }

    private void CheckParryInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(parryEnabled && !isAttacking)
            {
                isOnParryState = true;
                lastInputRightButtonTime = Time.time;
            }
        }
    }

    private void CheckParry()
    {
        if(isOnParryState && Input.GetMouseButton(1) && !isAttacking)
        {
            parryEnabled = false;
            if (Time.time <= lastInputRightButtonTime + parryWindow)
            {
                anim.SetBool("Parry", true);
            }
            else
            {
                anim.SetBool("Parry", false);
                anim.SetBool("Block", true);
            }
        }

        if (!Input.GetMouseButton(1))
        {
            isOnParryState = false;
            parryEnabled = true;
            anim.SetBool("Parry", false);
            anim.SetBool("Block", false);
        }
        
    }

    private void CheckAttacks()
    {
        if(gotLeftInput && !isAttacking && !isOnParryState) 
        {
                gotLeftInput = false;
                isAttacking = true;
                
                if (!isFirstAttack && !isSecondAttack && !isThirdAttack)
                {
                    isFirstAttack = !isFirstAttack;
                    anim.SetBool("Attack1", true); 
                    anim.SetBool("FirstAttack", isFirstAttack);
                    anim.SetBool("IsAttacking", isAttacking);
                }
                else if (isFirstAttack && !isSecondAttack && !isThirdAttack)
                {
                    isSecondAttack = !isSecondAttack;
                    anim.SetBool("Attack1", true);
                    anim.SetBool("SecondAttack", isSecondAttack);
                    anim.SetBool("IsAttacking", isAttacking);
                }
                else if (isFirstAttack && isSecondAttack && !isThirdAttack)
                {
                    isThirdAttack = !isThirdAttack;
                    anim.SetBool("Attack1", true);
                    anim.SetBool("ThirdAttack", isThirdAttack);
                    anim.SetBool("IsAttacking", isAttacking);  
                }   
        }
        
        if(Time.time >= lastInputTime + inputTimer)
        {
            //Wait for new input
            gotLeftInput = false;
            isAttacking = false;
            isFirstAttack = false;
            isSecondAttack = false;
            isThirdAttack = false;
            anim.SetBool("FirstAttack", isFirstAttack);
            anim.SetBool("SecondAttack", isSecondAttack);
            anim.SetBool("ThirdAttack", isThirdAttack);
            
        }
    }

    private void CheckAttack1HitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPosition.position, attack1Radius, whatIsDamageable);

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
            //Instantiate hit particle
        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("IsAttacking", isAttacking);
        anim.SetBool("Attack1", false);
    }

    private void FinishAttack2()
    {
        isAttacking = false;
        anim.SetBool("IsAttacking", isAttacking);
        anim.SetBool("Attack1", false);
    }

    private void FinishAttack3()
    {
        isAttacking = false;
        anim.SetBool("IsAttacking", isAttacking);
        isFirstAttack = false;
        isSecondAttack = false;
        isThirdAttack = false;
        anim.SetBool("FirstAttack", isFirstAttack);
        anim.SetBool("SecondAttack", isSecondAttack);
        anim.SetBool("ThirdAttack", isThirdAttack);
        anim.SetBool("Attack1", false);
    }

    

    private void Damage(AttackDetails attackDetails)
    {
        int direction;

        if (!isOnParryState)
        {
            ps.DecreaseHealth(attackDetails.damageAmount);

            if (attackDetails.position.x < transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            pc.Knockback(direction);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPosition.position, attack1Radius);
    }*/
}

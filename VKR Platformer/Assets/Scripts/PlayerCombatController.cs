using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attack1HitBoxPosition;
    [SerializeField]
    private LayerMask whatIsDamageable;


    private bool gotInput;
    private bool isAttacking;
    private bool isFirstAttack;
    private bool isSecondAttack;
    private bool isThirdAttack;

    private float lastInputTime = Mathf.NegativeInfinity;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("CanAttack", combatEnabled);
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(combatEnabled) 
            {
                gotInput = true;
                lastInputTime= Time.time;
            }
        }
    }

    private void CheckAttacks()
    {
        if(gotInput) 
        {
            if (!isAttacking)
            {
                gotInput = false;
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
        }
        
        if(Time.time >= lastInputTime + inputTimer + 0.3f)
        {
            //Wait for new input
            gotInput = false;
            isAttacking = false;
            anim.SetBool("FirstAttack", false);
            anim.SetBool("SecondAttack", isSecondAttack);
            anim.SetBool("ThirdAttack", isThirdAttack);
            isFirstAttack = false;
            isSecondAttack = false;
            isThirdAttack = false;
        }
    }

    private void CheckAttack1HitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPosition.position, attack1Radius, whatIsDamageable);
        
        foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attack1Damage);
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
        anim.SetBool("Attack1", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPosition.position, attack1Radius);
    }
}

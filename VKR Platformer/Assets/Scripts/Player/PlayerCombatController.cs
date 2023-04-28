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


    private bool 
        gotInput,
        isAttacking,
        isFirstAttack,
        isSecondAttack,
        isThirdAttack;

    private float[] attackDetails = new float[2];

    private float lastInputTime = Mathf.NegativeInfinity;

    private Animator anim;

    private PlayerController pc;
    private PlayerStats ps;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("CanAttack", combatEnabled);
        pc = GetComponent<PlayerController>();
        ps = GetComponent<PlayerStats>();
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
        
        if(Time.time >= lastInputTime + inputTimer)
        {
            //Wait for new input
            gotInput = false;
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

        attackDetails[0] = attack1Damage;
        attackDetails[1] = transform.position.x;

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

    private void TakeDamage(float[] attackDetails)
    {
        int direction;

        ps.DecreaseHealth(attackDetails[0]);

        if (attackDetails[1] < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        pc.Knockback(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPosition.position, attack1Radius);
    }
}

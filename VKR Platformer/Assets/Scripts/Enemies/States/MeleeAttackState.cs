using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    private CollisionsSences CollisionsSences { get => collisionsSences ??= core.GetCoreComponent<CollisionsSences>(); }
    private CollisionsSences collisionsSences;
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected D_MeleeAttack stateData;

    private int playerBlockCount = 0;
    private int playerDamageCount = 0;

    public MeleeAttackState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(stateMashine, entity, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        if (playerDamageCount == 0)
        {
            PlayerPrefs.SetInt("Untouchable", 1);
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        Collider2D[] detectedShield = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsShield);

        Collider2D shieldCollider = null;

        foreach (Collider2D collider in detectedShield)
        {
            if (collider != null)
            {
                shieldCollider = collider;
            }
        }


        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null && shieldCollider == null)
            {
                damageable.Damage(stateData.attackDamage);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if (knockbackable != null && shieldCollider != null)
            {
                knockbackable.Knockback(stateData.KnockbackAngle, stateData.knockbackStrenght - 2, Movement.FacingDirection);

                //Block Achievement
                PlayerPrefs.SetInt("First block", 1);

                //PlayerPrefs.SetInt("Block", ); ÎØÈÁÊÀ ÄÎÄÅËÀÉ

                if(playerBlockCount >= 5)
                {
                    PlayerPrefs.SetInt("Guardian", 1);
                }
                

            }
            else if (knockbackable != null)
            {
                knockbackable.Knockback(stateData.KnockbackAngle, stateData.knockbackStrenght, Movement.FacingDirection);

                //If the player takes damage, the achievement is lost.
                playerDamageCount++;
                
            }
        }
    }
}

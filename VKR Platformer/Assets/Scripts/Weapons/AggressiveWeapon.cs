using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggressiveWeapon : Weapon
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected SO_AggressiveWeaponData aggressiveWeaponData;

    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackable = new List<IKnockbackable>();

    protected int attackCounter;

    protected float endAttackTime;
    protected float resetAttackTime = 0.3f;

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_AggressiveWeaponData))
        {
            aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    public override void EnterWeapon()
    {
        base.EnterWeapon();

        if (attackCounter >= weaponData.amountOfAttacks || Time.time >= endAttackTime + resetAttackTime)
        {
            attackCounter = 0;
        }

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        baseAnimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", attackCounter);
    }

    public override void ExitWeapon()
    {
        endAttackTime = Time.time;

        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        base.ExitWeapon();
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        attackState.AnimationFinishTrigger();
    }

    public override void AnimationStartMovementTrigger()
    {
        base.AnimationStartMovementTrigger();

        attackState.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }

    public override void AnimationStopMovementTrigger()
    {
        base.AnimationStopMovementTrigger();

        attackState.SetPlayerVelocity(0.0f);
    }

    public override void AnimationTurnOffFlipTrigger()
    {
        base.AnimationTurnOffFlipTrigger();

        attackState.SetFlipCheck(false);
    }

    public override void AnimationTurnOnFlipTrigger()
    {
        base.AnimationTurnOnFlipTrigger();

        attackState.SetFlipCheck(true);
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];

        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);
        }

        foreach (IKnockbackable item in detectedKnockbackable.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, Movement.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {

        IDamageable damageable = collision.GetComponent<IDamageable>(); 
        
        if (damageable != null)
        {

            detectedDamageables.Add(damageable);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if(knockbackable != null)
        {
            detectedKnockbackable.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {

            detectedDamageables.Remove(damageable);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackable.Remove(knockbackable);
        }
    }
}

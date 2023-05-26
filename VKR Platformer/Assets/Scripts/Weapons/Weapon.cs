using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_WeaponData weaponData;

    protected Animator baseAnimator;
    protected Animator weaponAnimator;

    protected PlayerAttackState attackState;
    protected PlayerDefensiveState defensiveState;

    protected Player player;

    protected Core core;

    protected virtual void Awake()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);
    }

    public virtual void ExitWeapon()
    {
        gameObject.SetActive(false);
    }

    public virtual void AnimationFinishTrigger()
    {

    }

    public virtual void AnimationStartMovementTrigger()
    {

    }

    public virtual void AnimationStopMovementTrigger()
    {

    }

    public virtual void AnimationTurnOffFlipTrigger()
    {

    }

    public virtual void AnimationTurnOnFlipTrigger()
    {

    }

    public virtual void AnimationActionTrigger()
    {

    }

    public void InitialzeAggressiveWeapon(PlayerAttackState attackState, Core core)
    {
        this.attackState = attackState;
        this.core = core;
    }

    public void InitialzeDefensiveWeapon(PlayerDefensiveState defensiveState, Core core)
    {
        this.defensiveState = defensiveState;
        this.core = core;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveWeapon : Weapon
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected SO_DefensiveWeaponData defensiveWeaponData;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void EnterWeapon()
    {
        gameObject.SetActive(true);

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

    }

    public override void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }
}

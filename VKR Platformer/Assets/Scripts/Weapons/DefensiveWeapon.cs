using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;


public class DefensiveWeapon : Weapon
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected SO_DefensiveWeaponData defensiveWeaponData;

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(SO_DefensiveWeaponData))
        {
            defensiveWeaponData = (SO_DefensiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    

    public override void EnterWeapon()
    {
        base.EnterWeapon();

        baseAnimator.SetBool("shield", true);
        weaponAnimator.SetBool("shield", true);

        defensiveState.SetFlipCheck(false);
    }

    public override void ExitWeapon()
    {
        
        baseAnimator.SetBool("shield", false);
        weaponAnimator.SetBool("shield", false);

        defensiveState.SetFlipCheck(true);

        base.ExitWeapon();
    }

    
}

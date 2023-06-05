using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefensiveState : PlayerAbilityState
{
    private Weapon weapon;

    private int xInput;

    private bool shouldCheckFlip;

    public PlayerDefensiveState(Player player, PlayerStateMashine playerStateMashine, PlayerData playerData, string animBoolName) : base(player, playerStateMashine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (!player.InputHandler.AttackInputs[(int)(CombatInputs.second)])
        {
            isAbilityDone = true;
        }
    }

    public override void Enter()
    {
        base.Enter();

        weapon.EnterWeapon();
    }

    public override void Exit()
    {
        weapon.ExitWeapon();

        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0.0f);

        xInput = player.InputHandler.NormInputX;

        if (shouldCheckFlip)
        {
            Movement?.CheckIfShouldFlip(xInput);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        weapon.InitialzeDefensiveWeapon(this, core);
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }
}

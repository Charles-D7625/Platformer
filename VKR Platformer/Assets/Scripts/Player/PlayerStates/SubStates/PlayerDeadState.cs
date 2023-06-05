using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    public PlayerDeadState(Player player, PlayerStateMashine playerStateMashine, PlayerData playerData, string animBoolName) : base(player, playerStateMashine, playerData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Movement?.SetVelocityX(0.0f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerDetectedState : PlayerDetectedState
{
    private Goblin goblin;
    public Goblin_PlayerDetectedState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_PlayerDeteceted stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.goblin = goblin;
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            stateMashine.ChangeState(goblin.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            stateMashine.ChangeState(goblin.chargeState);
        }
        else if(!isPlayerInMaxAgroRange)
        {
            stateMashine.ChangeState(goblin.lookForPlayerState);
        }
        else if (!isDetectedLedge)
        {
            entity.Flip();
            stateMashine.ChangeState(goblin.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

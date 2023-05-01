using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_ChargeState : ChargeState
{
    private Goblin goblin;

    public Goblin_ChargeState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_ChargeState stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, stateData)
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
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMashine.ChangeState(goblin.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {

            if (isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(goblin.playerDetectedState);
            }
            else
            {
                stateMashine.ChangeState(goblin.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

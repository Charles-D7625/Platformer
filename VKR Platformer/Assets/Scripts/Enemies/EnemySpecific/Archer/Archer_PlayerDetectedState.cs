using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_PlayerDetectedState : PlayerDetectedState
{
    private Archer archer;
    public Archer_PlayerDetectedState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_PlayerDeteceted stateData, Archer archer) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.archer = archer;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionsSences)
        {
            isDetectedLedge = CollisionsSences.LedgeVertical;
        }
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

        if (archer.Stats.currentHealth <= 0)
        {
            stateMashine.ChangeState(archer.deadState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMashine.ChangeState(archer.lookForPlayerState);
        }
        else if (performLongRangeAction)
        {
            stateMashine.ChangeState(archer.rangeAttackState);
        }
        else if (!isDetectedLedge)
        {
            Movement?.Flip();
            stateMashine.ChangeState(archer.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

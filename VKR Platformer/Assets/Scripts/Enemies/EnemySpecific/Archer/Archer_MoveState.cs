using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_MoveState : MoveState
{

    private Archer archer;
    public Archer_MoveState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_MoveState stateData, Archer archer) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.archer = archer;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionsSences)
        {
            isDetectingLedge = CollisionsSences.LedgeVertical;
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
        else if (isHitted)
        {
            stateMashine.ChangeState(archer.hitState);
        }
        else if (isPlayerInMinAgroRange)
        {
            stateMashine.ChangeState(archer.playerDetectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            archer.idleState.SetFlipAfterIdle(true);
            stateMashine.ChangeState(archer.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

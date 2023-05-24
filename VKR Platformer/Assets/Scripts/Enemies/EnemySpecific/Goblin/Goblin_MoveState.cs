using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_MoveState : MoveState
{
    private Goblin goblin;

    public Goblin_MoveState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_MoveState stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.goblin = goblin;
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

        if (isPlayerInMinAgroRange)
        {
            stateMashine.ChangeState(goblin.playerDetectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            goblin.idleState.SetFlipAfterIdle(true);
            stateMashine.ChangeState(goblin.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_LookForPlayerState : LookForPlayerState
{
    private Goblin goblin;
    public Goblin_LookForPlayerState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_LookForPlayer stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, stateData)
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

        if (isPlayerInMinAgroRange)
        {
            stateMashine.ChangeState(goblin.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMashine.ChangeState(goblin.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

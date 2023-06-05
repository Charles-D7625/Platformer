using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_IdleState : IdleState
{
    private Goblin goblin;

    public Goblin_IdleState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_IdleState stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, stateData)
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

        if (isHitted)
        {
            stateMashine.ChangeState(goblin.hitState);
        }
        else if(isPlayerInMinAgroRange)
        {
            stateMashine.ChangeState(goblin.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMashine.ChangeState(goblin.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

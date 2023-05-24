using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_IdleState : IdleState
{
    private Archer archer;
    public Archer_IdleState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_IdleState stateData, Archer archer) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.archer = archer;
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
        else if (isIdleTimeOver)
        {
            stateMashine.ChangeState(archer.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

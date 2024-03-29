using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    private Enemy1 enemy;

    public E1_IdleState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_IdleState stateData, Enemy1 enemy) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.enemy = enemy;
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
            stateMashine.ChangeState(enemy.hitState);
        }
        else if (isPlayerInMinAgroRange)
        {
            stateMashine.ChangeState(enemy.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMashine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

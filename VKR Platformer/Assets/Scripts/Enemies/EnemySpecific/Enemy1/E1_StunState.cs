using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_StunState : StunState
{
    protected Enemy1 enemy;

    public E1_StunState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_StunState stateData, Enemy1 enemy) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.enemy = enemy;
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

        if(isStunTimeOver)
        {
            if(performCloseRangeAction)
            {
                stateMashine.ChangeState(enemy.meleeAttackState);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(enemy.chargeState);
            }
            else
            {
                enemy.lookForPlayerState.SetTurnImmediatly(true);
                stateMashine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

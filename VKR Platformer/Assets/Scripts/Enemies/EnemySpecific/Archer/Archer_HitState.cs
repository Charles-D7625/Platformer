using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_HitState : HitState
{
    private Archer archer;
    public Archer_HitState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_HitState stateData, Archer archer) : base(stateMashine, entity, animBoolName, stateData)
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
        else if (isHitTimaOver)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(archer.playerDetectedState);
            }
            else
            {
                archer.lookForPlayerState.SetTurnImmediatly(true);
                stateMashine.ChangeState(archer.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

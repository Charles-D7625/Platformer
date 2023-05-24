using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_RangeAttackState : RangeAttackState
{
    private Archer archer;
    public Archer_RangeAttackState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, Transform attackPosition, 
        D_RangeAttackState stateData, Archer archer) : base(stateMashine, entity, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinish)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(archer.playerDetectedState);
            }
            else
            {
                stateMashine.ChangeState(archer.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack(); 
    }
}

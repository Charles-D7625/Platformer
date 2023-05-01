using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : State
{
    protected D_HitState stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;

    public HitState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_HitState stateData) : base(stateMashine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

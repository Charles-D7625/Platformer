using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitState : State
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected D_HitState stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;
    protected bool isHitTimaOver;

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

        isHitTimaOver = false;
        Movement?.SetVelocityX(0.0f);
    }

    public override void Exit()
    {
        base.Exit();
        entity.Stats.isHitActive = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.hitTime)
        {
            isHitTimaOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void HitTimeIsOver()
    {
        isHitTimaOver = true;
    }
}

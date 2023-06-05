using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected CollisionsSences CollisionsSences { get => collisionsSences ??= core.GetCoreComponent<CollisionsSences>(); }
    private CollisionsSences collisionsSences;
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected D_ChargeState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;
    public ChargeState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_ChargeState stateData) : base(stateMashine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionsSences)
        {
            isDetectingWall = CollisionsSences.WallFront;
        }
        
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);

        if (Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

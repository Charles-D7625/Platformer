using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    private CollisionsSences CollisionsSences { get => collisionsSences ??= core.GetCoreComponent<CollisionsSences>(); }
    private CollisionsSences collisionsSences;
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected D_StunState stateData;

    protected bool isStunTimeOver;
    protected bool isGrounded;
    protected bool isMovementStopped;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;
    public StunState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_StunState stateData) : base(stateMashine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if (CollisionsSences)
        {
            isGrounded = CollisionsSences.Ground;
        }

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isStunTimeOver = false;
        isMovementStopped = false;
        Movement?.SetVelocity(stateData.stunKnockbackSpeed, stateData.stunKnockbackAngle, entity.lastDamageDirection);
    }

    public override void Exit()
    {
        base.Exit();
        entity.ResetStunResistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.stunTime)
        {
            isStunTimeOver = true;
        }

        if(isGrounded && Time.time >= startTime + stateData.stunTime && !isMovementStopped)
        {
            isMovementStopped = true;
            Movement?.SetVelocityX(0.0f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected Transform attackPosition;

    protected bool isAnimationFinish;
    protected bool isPlayerInMinAgroRange;

    public AttackState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, Transform attackPosition) : base(stateMashine, entity, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;
        isAnimationFinish = false;
        Movement?.SetVelocityX(0.0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0.0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinish = true;
    }
}

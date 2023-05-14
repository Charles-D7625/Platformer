using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    protected D_DeadState stateData;

    public DeadState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_DeadState stateData) : base(stateMashine, entity, animBoolName)
    {
        this.stateData = stateData;
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

        Movement?.SetVelocityX(0.0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

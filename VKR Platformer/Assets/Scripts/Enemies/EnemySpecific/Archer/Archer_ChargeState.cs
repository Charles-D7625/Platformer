using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_ChargeState : ChargeState
{
    private Archer archer;
    public Archer_ChargeState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_ChargeState stateData, Archer archer) : base(stateMashine, entity, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

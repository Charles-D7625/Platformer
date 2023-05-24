using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye_DeadState : DeadState
{
    private EvilEye evilEye;
    public EvilEye_DeadState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_DeadState stateData, EvilEye evilEye) : base(stateMashine, entity, animBoolName, stateData)
    {
        this.evilEye = evilEye;
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

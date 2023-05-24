using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye_MoveState : MoveState
{
    private EvilEye evilEye;
    public EvilEye_MoveState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_MoveState stateData, EvilEye evilEye) : base(stateMashine, entity, animBoolName, stateData)
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

        if (isHitted)
        {
            stateMashine.ChangeState(evilEye.hitState);
        }
        else if (isPlayerInMinAgroRange)
        {
            stateMashine.ChangeState(evilEye.playerDetectedState);
        }
        else if (isDetectingWall)
        {
            evilEye.idleState.SetFlipAfterIdle(true);
            stateMashine.ChangeState(evilEye.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

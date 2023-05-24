using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye_PlayerDetectedState : PlayerDetectedState
{
    private EvilEye evilEye;
    public EvilEye_PlayerDetectedState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_PlayerDeteceted stateData, EvilEye evilEye) : base(stateMashine, entity, animBoolName, stateData)
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

        if (performCloseRangeAction)
        {
            stateMashine.ChangeState(evilEye.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            stateMashine.ChangeState(evilEye.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMashine.ChangeState(evilEye.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

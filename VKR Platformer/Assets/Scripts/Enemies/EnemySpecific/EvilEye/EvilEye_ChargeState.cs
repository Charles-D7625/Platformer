using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye_ChargeState : ChargeState
{
    private EvilEye evilEye;

    public EvilEye_ChargeState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_ChargeState stateData, EvilEye evilEye) : base(stateMashine, entity, animBoolName, stateData)
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

        if (performCloseRangeAction || performCloseRangeActionWithShield)
        {
            stateMashine.ChangeState(evilEye.meleeAttackState);
        }
        else if (isDetectingWall)
        {
            stateMashine.ChangeState(evilEye.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {

            if (isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(evilEye.playerDetectedState);
            }
            else
            {
                stateMashine.ChangeState(evilEye.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

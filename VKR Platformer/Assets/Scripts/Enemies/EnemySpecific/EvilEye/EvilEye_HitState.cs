using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye_HitState : HitState
{
    private EvilEye evilEye;
    public EvilEye_HitState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_HitState stateData, EvilEye evilEye) : base(stateMashine, entity, animBoolName, stateData)
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

        if (isHitTimaOver)
        {
            if (performCloseRangeAction)
            {
                stateMashine.ChangeState(evilEye.meleeAttackState);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(evilEye.playerDetectedState);
            }
            else if (!isPlayerInMinAgroRange)
            {
                evilEye.lookForPlayerState.SetTurnImmediatly(true);
                stateMashine.ChangeState(evilEye.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

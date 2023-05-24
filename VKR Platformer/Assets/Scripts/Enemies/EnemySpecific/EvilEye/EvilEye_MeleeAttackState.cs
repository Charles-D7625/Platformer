using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye_MeleeAttackState : MeleeAttackState
{
    private EvilEye evilEye;
    public EvilEye_MeleeAttackState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, EvilEye evilEye) : base(stateMashine, entity, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinish)
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_MeleeAttackState : MeleeAttackState
{
    private Goblin goblin;
    public Goblin_MeleeAttackState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, attackPosition, stateData)
    {
        this.goblin = goblin;
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

        if(isAnimationFinish)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(goblin.playerDetectedState);
            }
            else if (!isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(goblin.lookForPlayerState);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_StunState : StunState
{
    private Goblin goblin;
    public Goblin_StunState(FiniteStateMashine stateMashine, Entity entity, string animBoolName, D_StunState stateData, Goblin goblin) : base(stateMashine, entity, animBoolName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isStunTimeOver)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(goblin.playerDetectedState);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMashine.ChangeState(goblin.chargeState);
            }
            else
            {
                stateMashine.ChangeState(goblin.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

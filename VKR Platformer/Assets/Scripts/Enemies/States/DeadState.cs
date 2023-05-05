using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
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

        /*if (Time.time <= startTime + stateData.timeDeadAnimation)
        {
            entity.anim.SetFloat("health", entity.currentHealth);
            entity.aliveGO.layer = 8; // dead layer
        }
        else
        {
            entity.deadGO.transform.position = entity.aliveGO.transform.position;
            entity.aliveGO.SetActive(false);
            entity.deadGO.SetActive(true);
        }*/
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

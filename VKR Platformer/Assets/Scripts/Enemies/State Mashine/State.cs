using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMashine stateMashine;
    protected Entity entity;
    protected Core core;

    public float startTime { get; protected set; }

    protected string animBoolName;

    public State(FiniteStateMashine stateMashine, Entity entity, string animBoolName)
    {
        this.stateMashine = stateMashine;
        this.entity = entity;
        this.animBoolName = animBoolName;
        core = entity.Core;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() 
    {

    }
}

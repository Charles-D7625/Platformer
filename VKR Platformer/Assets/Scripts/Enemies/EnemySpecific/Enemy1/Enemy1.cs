using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetecetedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_DeadState deadState { get; private set; }

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDeteceted playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    public override void Start()
    {
        base.Start();


        moveState = new E1_MoveState(stateMashine, this, "move", moveStateData, this);
        idleState = new E1_IdleState(stateMashine, this, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetecetedState(stateMashine, this, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(stateMashine, this, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(stateMashine, this, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E1_MeleeAttackState(stateMashine, this, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new E1_StunState(stateMashine, this, "stun", stunStateData, this);
        deadState = new E1_DeadState(stateMashine, this, "dead", deadStateData, this);

        stateMashine.Initialize(moveState);

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMashine.ChangeState(deadState);
        }
        else if (isStunned && stateMashine.currentState != stunState)
        {
            stateMashine.ChangeState(stunState);
        }

        
    }
}

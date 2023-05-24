using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Entity
{
    public Archer_IdleState idleState { get; private set; }
    public Archer_MoveState moveState { get; private set; }
    public Archer_PlayerDetectedState playerDetectedState { get; private set; }
    public Archer_ChargeState chargeState { get; private set; }
    public Archer_LookForPlayerState lookForPlayerState { get; private set; }
    public Archer_DeadState deadState { get; private set; }
    public Archer_HitState hitState { get; private set; }
    public Archer_RangeAttackState rangeAttackState { get; private set; }

    [SerializeField] private Transform rangeAttackPosition;

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDeteceted playerDetectedData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_HitState hitStateData;
    [SerializeField] private D_RangeAttackState rangeAttackStateData;
    public override void Awake()
    {
        base.Awake();

        moveState = new Archer_MoveState(stateMashine, this, "move", moveStateData, this);
        idleState = new Archer_IdleState(stateMashine, this, "idle", idleStateData, this);
        deadState = new Archer_DeadState(stateMashine, this, "dead", deadStateData, this);
        playerDetectedState = new Archer_PlayerDetectedState(stateMashine, this, "playerDetected", playerDetectedData, this);
        hitState = new Archer_HitState(stateMashine, this, "hit", hitStateData, this);
        lookForPlayerState = new Archer_LookForPlayerState(stateMashine, this, "lookForPlayer", lookForPlayerStateData, this);
        rangeAttackState = new Archer_RangeAttackState(stateMashine, this, "rangeAttack", rangeAttackPosition, rangeAttackStateData, this);
        
        /*stunState = new E1_StunState(stateMashine, this, "stun", stunStateData, this);      
        
        chargeState = new E1_ChargeState(stateMashine, this, "charge", chargeStateData, this);*/
    }

    private void Start()
    {
        stateMashine.Initialize(moveState);
    }

    public override void Update()
    {
        base.Update();

        if (Stats.currentHealth <= 0)
        {
            stateMashine.ChangeState(deadState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(rangeAttackPosition.position, rangeAttackStateData.attackRadius);
    }


}

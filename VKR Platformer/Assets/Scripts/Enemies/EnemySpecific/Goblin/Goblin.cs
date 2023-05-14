using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Goblin : Entity
{
    public Goblin_IdleState idleState { get; private set; }
    public Goblin_MoveState moveState { get; private set; }
    public Goblin_PlayerDetectedState playerDetectedState { get; private set; }
    public Goblin_MeleeAttackState meleeAttackState { get; private set; }
    public Goblin_LookForPlayerState lookForPlayerState { get; private set;}
    public Goblin_StunState stunState { get; private set; }
    public Goblin_DeadState deadState { get; private set; }
    public Goblin_ChargeState chargeState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDeteceted playerDetectedData;
    [SerializeField] private D_MeleeAttack meleeAttackStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_StunState stunStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_ChargeState chargeStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        moveState = new Goblin_MoveState(stateMashine, this, "move", moveStateData, this);
        idleState = new Goblin_IdleState(stateMashine, this, "idle", idleStateData, this);
        playerDetectedState = new Goblin_PlayerDetectedState(stateMashine, this, "playerDetected", playerDetectedData, this);
        meleeAttackState = new Goblin_MeleeAttackState(stateMashine, this, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new Goblin_LookForPlayerState(stateMashine, this, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new Goblin_StunState(stateMashine, this, "stun", stunStateData, this);
        deadState = new Goblin_DeadState(stateMashine, this, "dead", deadStateData, this);
        chargeState = new Goblin_ChargeState(stateMashine, this, "charge", chargeStateData, this);

    }
    private void Start()
    {
        stateMashine.Initialize(moveState);
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}

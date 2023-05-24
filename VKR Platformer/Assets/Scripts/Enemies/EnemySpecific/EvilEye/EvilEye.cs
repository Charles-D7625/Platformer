using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEye : Entity
{
    public EvilEye_IdleState idleState { get; private set; }
    public EvilEye_MoveState moveState { get; private set; }
    public EvilEye_PlayerDetectedState playerDetectedState { get; private set; }
    public EvilEye_ChargeState chargeState { get; private set; }
    public EvilEye_LookForPlayerState lookForPlayerState { get; private set; }
    public EvilEye_MeleeAttackState meleeAttackState { get; private set; }
    public EvilEye_DeadState deadState { get; private set; }
    public EvilEye_HitState hitState { get; private set; }

    [SerializeField] private Transform meleeAttackPosition;

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDeteceted playerDetectedData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateData;
    [SerializeField] private D_MeleeAttack meleeAttackStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_HitState hitStateData;

    public override void Awake()
    {
        base.Awake();

        moveState = new EvilEye_MoveState(stateMashine, this, "move", moveStateData, this);
        idleState = new EvilEye_IdleState(stateMashine, this, "idle", idleStateData, this);
        playerDetectedState = new EvilEye_PlayerDetectedState(stateMashine, this, "playerDetected", playerDetectedData, this);
        chargeState = new EvilEye_ChargeState(stateMashine, this, "charge", chargeStateData, this);
        lookForPlayerState = new EvilEye_LookForPlayerState(stateMashine, this, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new EvilEye_MeleeAttackState(stateMashine, this, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new EvilEye_DeadState(stateMashine, this, "dead", deadStateData, this);
        hitState = new EvilEye_HitState(stateMashine, this, "hit", hitStateData, this);
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
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);

        if (Core != null)
        {
            if (CollisionsSences)
            {
                Gizmos.DrawLine(collisionsSences.WallCheck.position, collisionsSences.WallCheck.position + (Vector3)(Vector2.left * Movement.FacingDirection * collisionsSences.GroundCheckRadius));

                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance) * Movement.FacingDirection, 0.2f);
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance) * Movement.FacingDirection, 0.2f);
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance) * Movement.FacingDirection, 0.2f);
            }
        }
    }
}

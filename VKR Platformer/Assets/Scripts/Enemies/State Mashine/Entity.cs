using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected CollisionsSences CollisionsSences { get => collisionsSences ??= Core.GetCoreComponent<CollisionsSences>(); }
    protected CollisionsSences collisionsSences;
    protected Movement Movement { get => movement ??= Core.GetCoreComponent<Movement>(); }
    protected Movement movement;
    public Stats Stats { get => stats ??= Core.GetCoreComponent<Stats>(); }
    private Stats stats;

    public FiniteStateMashine stateMashine;

    public D_Entity entityData;

    public Animator anim { get; private set; }
    public AnimationToStatemashine atsm { get; private set; }
    public Core Core { get; private set; }

    [SerializeField] protected Transform playerCheck;

    private float currentStunResistence;
    private float lastDamageTime;

    public int lastDamageDirection { get; private set; }

    private Vector2 velocityWorkspace;

    protected bool isStunned;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        currentStunResistence = entityData.stunResistance;

        anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStatemashine>();

        stateMashine = new FiniteStateMashine();
    }

    public virtual void Update()
    {
        Core.LogicUpdate();

        stateMashine.currentState.LogicUpdate();

        if(Time.time >=  lastDamageTime + entityData.stunResistance && isStunned)
        {
            ResetStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMashine.currentState.PhysicsUpdate();
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckHit()
    {
        return Stats.isHitActive;
    }


    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(Movement.RB.velocity.x, velocity);
        Movement.RB.velocity = velocityWorkspace;
    }

    public virtual void ResetStunResistance()
    {
        isStunned = false;
        currentStunResistence = entityData.stunResistance;
    }

    public virtual void OnDrawGizmos()
    {
        if(Core != null)
        {
            if (CollisionsSences)
            {
                Gizmos.DrawLine(collisionsSences.WallCheck.position, collisionsSences.WallCheck.position + (Vector3)(Vector2.left * Movement.FacingDirection * collisionsSences.WallCheckDistance));
                Gizmos.DrawLine(collisionsSences.LedgeCheckVertical.position, collisionsSences.LedgeCheckVertical.position + (Vector3)(Vector2.down * collisionsSences.GroundCheckRadius));

                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
                Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
            }   
        }
    }
}

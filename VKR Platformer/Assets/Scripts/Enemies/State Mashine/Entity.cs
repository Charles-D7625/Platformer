using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Movement Movement { get => movement ??= Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    public FiniteStateMashine stateMashine;

    public D_Entity entityData;

    public Animator anim { get; private set; }
    public AnimationToStatemashine atsm { get; private set; }
    public Core Core { get; private set; }

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform groundCheck;

    public float currentHealth { get; private set; }
    private float currentStunResistence;
    private float lastDamageTime;

    public int lastDamageDirection { get; private set; }

    private Vector2 velocityWorkspace;

    protected bool isStunned;
    protected bool isDead;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        currentHealth = entityData.maxHealth;
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
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.left * Movement.FacingDirection * entityData.wallCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMashine stateMashine;

    public D_Entity entityData;

    public int facingDirection { get; private set; }

    public Rigidbody2D aliveRB { get; private set; }
    public Rigidbody2D deadRB { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public GameObject deadGO { get; private set; }
    public AnimationToStatemashine atsm { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;

    public float currentHealth { get; private set; }
    private float currentStunResistence;
    private float lastDamageTime;

    public int lastDamageDirection { get; private set; }

    private Vector2 velocityWorkspace;

    protected bool isStunned;
    protected bool isDead;

    public virtual void Start()
    {
        facingDirection = 1;
        currentHealth = entityData.maxHealth;
        currentStunResistence = entityData.stunResistance;

        aliveGO = transform.Find("Alive").gameObject;
        deadGO = transform.Find("Dead").gameObject;

        aliveRB = aliveGO.GetComponent<Rigidbody2D>();
        deadRB = deadGO.GetComponent<Rigidbody2D>();

        anim = aliveGO.GetComponent<Animator>();
        atsm = aliveGO.GetComponent<AnimationToStatemashine>();

        stateMashine = new FiniteStateMashine();
    }

    public virtual void Update()
    {
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

    public virtual void SetVelocity(float velocity) // add to entity his speed
    {
        velocityWorkspace.Set(facingDirection * velocity, aliveRB.velocity.y);
        aliveRB.velocity = velocityWorkspace;
    }

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction) // add entity a some reaction to any state
    {
        angle.Normalize();
        velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        aliveRB.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, -aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadius, entityData.whatIsGround);
    }
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, -aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, -aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, -aliveGO.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(aliveRB.velocity.x, velocity);
        aliveRB.velocity = velocityWorkspace;
    }

    public virtual void ResetStunResistance()
    {
        isStunned = false;
        currentStunResistence = entityData.stunResistance;
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        lastDamageTime = Time.time;

        currentHealth -= attackDetails.damageAmount;
        currentStunResistence -= attackDetails.stunDamageAmount;

        DamageHop(entityData.damageHopSpeed);

        if (attackDetails.position.x > aliveGO.transform.position.x)
        {
            lastDamageDirection = -1;
        }
        else
        {
            lastDamageDirection = 1;
        }

        if(currentStunResistence <= 0)
        {
            isStunned = true;
        }

        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.left * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
    }
}

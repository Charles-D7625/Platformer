using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private float distance;
    private float xStartPosition;
    private float damage;
    private float knockbackStrenght;
    private int facingDirection;
    private Vector2 knockbackAngle;

    [SerializeField] private float gravity;
    [SerializeField] private float damageRadius;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsShield;

    [SerializeField] private Transform damagePosition;

    private Rigidbody2D RB;

    private bool isGravityOn;
    private bool onGround;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        
        RB.gravityScale = 0.0f;
        RB.velocity = transform.right * speed;

        isGravityOn = false;

        xStartPosition = transform.position.x;
    }

    private void Update()
    {
        if (!onGround && isGravityOn)
        {
            float angle = Mathf.Atan2(RB.velocity.y, RB.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        if (!onGround)
        {
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius, whatIsPlayer);

            Collider2D[] detectedShield = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius, whatIsShield);

            Collider2D shieldCollider = null;

            foreach (Collider2D collider in detectedShield)
            {
                if (collider != null)
                {
                    shieldCollider = collider;
                }
            }

            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                if (damageable != null && shieldCollider == null)
                {
                    damageable.Damage(damage);
                }

                IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

                if (knockbackable != null && shieldCollider != null)
                {
                    knockbackable.Knockback(knockbackAngle, knockbackStrenght - 2, facingDirection);
                    
                    Destroy(gameObject);
                }
                else if (knockbackable != null)
                {
                    knockbackable.Knockback(knockbackAngle, knockbackStrenght, facingDirection);
                    Destroy(gameObject);
                }
            }

            if (groundHit)
            {
                onGround = true;
                RB.gravityScale = 0.0f;
                RB.velocity = Vector2.zero;
                Destroy(gameObject);
            }

            if (Mathf.Abs(xStartPosition - transform.position.x) >= distance && isGravityOn != true)
            {
                isGravityOn = true;
                RB.gravityScale = gravity;
            }
        }
        else
        {
            onGround = true;
            RB.gravityScale = 0.0f;
            RB.velocity = Vector2.zero; 
        }

    }

    public void FireProjectile(float speed, float distance, float damage, float knockbackStrenght, int facingDirection, Vector2 knockbackAngle)
    {
        this.speed = speed;
        this.distance = distance;
        this.damage = damage;
        this.knockbackStrenght = knockbackStrenght;
        this.facingDirection = facingDirection;
        this.knockbackAngle = knockbackAngle;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}

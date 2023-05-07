using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    private CollisionsSences CollisionsSences { get => collisionsSences ??= core.GetCoreComponent<CollisionsSences>(); }
    private CollisionsSences collisionsSences;
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private Stats Stats { get => stats ??= core.GetCoreComponent<Stats>(); }
    private Stats stats;

    [SerializeField] private float maxKnockbackTime = 0.2f;

    private bool isKnobackActive;
    private float knockbackStartTime;

    public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " damaged");
        Stats?.DecreaseHealth(amount);
    }

    public void Knockback(Vector2 angle, float strenght, int direction)
    {
        Movement?.SetVelocity(strenght, angle, direction);
        Movement.CanSetVelocity = false;
        isKnobackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (isKnobackActive && (Movement.CurrentVelocity.y <= 0.01f && CollisionsSences.Ground) || Time.time >= knockbackStartTime + maxKnockbackTime)
        {
            isKnobackActive = false;
            Movement.CanSetVelocity = true;
        }
    }
}

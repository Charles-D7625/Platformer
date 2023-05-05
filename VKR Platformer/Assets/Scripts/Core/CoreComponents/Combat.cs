using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
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
        core.Stats.DecreaseHealth(amount);
    }

    public void Knockback(Vector2 angle, float strenght, int direction)
    {
        core.Movement.SetVelocity(strenght, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnobackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if (isKnobackActive && (core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionsSences.Ground) || Time.time >= knockbackStartTime + maxKnockbackTime)
        {
            isKnobackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangeAttackStateData", menuName = "Data/State Data/Range Attack State")]

public class D_RangeAttackState : ScriptableObject
{
    public GameObject projectile;

    public float projectileDamage = 10.0f;
    public float projectileSpeed = 12.0f;
    public float projectileDistance = 8.0f;
    public float knockbackStrenght = 10.0f;

    public Vector2 KnockbackAngle = Vector2.one;

    public float attackRadius = 0.3f;

    public AudioClip arrowSound;
}

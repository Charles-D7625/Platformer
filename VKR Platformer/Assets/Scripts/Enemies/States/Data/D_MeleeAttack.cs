using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]

public class D_MeleeAttack : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10.0f;

    public Vector2 KnockbackAngle = Vector2.one;
    public float knockbackStrenght = 10.0f;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsShield;

    public AudioClip meleeAttackSound;
    public AudioClip shieldAttackSound;
}

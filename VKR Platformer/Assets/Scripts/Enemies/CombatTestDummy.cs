using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour, IDamageable
{
    private Animation anim;

    public void Damage(float amount)
    {
        Debug.Log(amount);

        Destroy(gameObject);
    }

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
}

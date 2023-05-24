using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class D_Entity : ScriptableObject
{
    public float damageHopSpeed = 3.0f;

    public float maxAgroDistance = 12.0f;
    public float minAgroDistance = 10.0f;

    public float stunResistance = 3.0f;
    public float stunRecoveryTime = 2.0f;

    public float closeRangeActionDistance = 1.0f;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsShield;

}

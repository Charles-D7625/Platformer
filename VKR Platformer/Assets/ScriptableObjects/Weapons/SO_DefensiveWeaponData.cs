using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDefensiveWeaponData", menuName = "Data/Weapon Data/Defensive Weapon")]

public class SO_DefensiveWeaponData : SO_WeaponData
{
    [SerializeField] private WeaponDefendDetails[] defendDetails;

    public WeaponDefendDetails[] DefendDetails { get => defendDetails; private set => defendDetails = value; }
}

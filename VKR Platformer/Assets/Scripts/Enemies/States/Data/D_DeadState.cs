using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "newDeadStateData", menuName = "Data/State Data/Dead State")]

public class D_DeadState : ScriptableObject
{
    public float timeDeadAnimation = 1.0f;
}

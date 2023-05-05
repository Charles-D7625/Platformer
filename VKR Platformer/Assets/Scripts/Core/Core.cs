using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);

        private set => movement = value;
        
    }
    public CollisionsSences CollisionsSences
    {
        get => GenericNotImplementedError<CollisionsSences>.TryGet(collisionsSences, transform.parent.name);

        private set => collisionsSences = value;
    }

    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);

        private set => combat = value;
    }

    public Stats Stats
    {
        get => GenericNotImplementedError<Stats>.TryGet(stats, transform.parent.name);

        private set => stats = value;
    }

    private Movement movement;
    private CollisionsSences collisionsSences;
    private Combat combat;
    private Stats stats;

    private List<ILogicUpdate> components = new List<ILogicUpdate>();
    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionsSences = GetComponentInChildren<CollisionsSences>();
        Combat = GetComponentInChildren<Combat>();
        Stats = GetComponentInChildren<Stats>();          
    }

    public void LogicUpdate()
    {
        foreach (ILogicUpdate component in components)
        {
            component.LogicUpdate();
        }
    }

    public void AddComponent(ILogicUpdate component)
    {
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }
}

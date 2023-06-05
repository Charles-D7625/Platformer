using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    public GameObject DeadGO
    {
        get => GenericNotImplementedError<GameObject>.TryGet(deadGO, core.transform.parent.name);

        private set => deadGO = value;
    }
    
    [SerializeField] private GameObject deadGO;

    private Stats Stats { get => stats ??= core.GetCoreComponent<Stats>(); }
    private Stats stats;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void LogicUpdate()
    {
        
    }

    public void Die()
    {
        GameObject.Instantiate(DeadGO, core.transform.parent.position, core.transform.parent.rotation);
        Destroy(core.transform.parent.gameObject);
        //core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}

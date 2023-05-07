using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalManager : CoreComponent
{
    private GameObject[] particals;

    private Transform particalContainer;

    protected override void Awake()
    {
        base.Awake();

        particals = GameObject.FindGameObjectsWithTag("ParticalContainer");

        foreach (GameObject item in particals)
        {
            particalContainer = item.transform;
        }
    }

    public GameObject StartParticals(GameObject particalPrefab, Vector2 position, Quaternion rotation)
    {
        return Instantiate(particalPrefab, position, rotation, particalContainer);
    }

    public GameObject StartParticals(GameObject particalPrefab)
    {
        return StartParticals(particalPrefab, transform.position, Quaternion.identity);
    }

    
}
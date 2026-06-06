using UnityEngine;
using System;

public class EggSpawner : MonoBehaviour
{
    public static EggSpawner Instance
    {
        get { return instance; }
    }
    private static EggSpawner instance;

    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject player;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void SpawnEgg()
    {
        Vector3 spawnLocation = new Vector3(player.transform.position.x, 5.0f, 0);

        Instantiate(egg);
        egg.transform.position = spawnLocation;
    }
}

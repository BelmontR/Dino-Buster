using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float frequency; //in Sekunden. freq = 5 -> Alle 5s wird was gespawnt
    public GameObject spawnableThing;

    private float lastSpawnedTimeStamp = Mathf.NegativeInfinity;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentEnemies < GameManager.instance.maxEnemies)
        {
            if (Time.time - lastSpawnedTimeStamp >= frequency ||lastSpawnedTimeStamp == Mathf.NegativeInfinity)
            {
                Spawn();
                lastSpawnedTimeStamp = Time.time;
            }
        }
    }

    public void Spawn()
    {
        var enemy = Instantiate<GameObject>(spawnableThing, transform.position, transform.rotation);
        enemy.transform.parent = null; //Evlt. redundant, aber sicher ist sicher
        GameManager.instance.currentEnemies++;
    }
}

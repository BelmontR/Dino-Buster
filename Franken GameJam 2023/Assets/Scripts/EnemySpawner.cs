using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float frequency; //in Sekunden. freq = 5 -> Alle 5s wird was gespawnt
    public GameObject spawnableThing;

    private float lastSpawnedTimeStamp = Mathf.NegativeInfinity;
    public bool active = true;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentEnemies < GameManager.instance.maxEnemies && active)
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
        int rnd = UnityEngine.Random.Range(0, GameManager.instance.enemyPrefabs.Length);

        var enemy = Instantiate<Enemy>(GameManager.instance.enemyPrefabs[rnd].GetComponent<Enemy>(), transform.position, transform.rotation);
        enemy.transform.parent = null; //Evlt. redundant, aber sicher ist sicher

        GameManager.instance.currentEnemies++;
        GameManager.instance.spawnedEnemies.Add(enemy.GetComponent<Enemy>());
    }

    //Dadurch können nur Spawner außerhalb der Kamera auch Gegner spawnen -> Es "ploppen" keine Gegner aus dem nichts raus, sondern sie kommen vom Rand hergelaufen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Camera>() != null)
        {
            active = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Camera>() != null)
        {
            active = true;
        }
    }
}

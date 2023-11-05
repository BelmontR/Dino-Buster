using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score;
    private int killedEnemies;

    public int maxEnemies;
    public int maxItemsOnScreen;

    public int currentEnemies;
    public int currentItemsOnScreen;

    public Enemy[] enemyPrefabs;

    public List<Enemy> spawnedEnemies;

    public Player player;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 1;

        StartCoroutine(GamePlayCoro());
    }

    public void AddToScore(int increment)
    {
        score += increment;
    }

    public void IncrementKilledEnemies()
    {
        killedEnemies++;
    }

    public void ScaleEnemies(float scalePercentage)
    {
        foreach(var enemy in enemyPrefabs)
        {
            enemy.speed *= (1 + 0.2f * scalePercentage);
            enemy.hp *= (1 + 0.3f * scalePercentage);
        }
    }

    public void KillAllEnemies()
    {
        var x = spawnedEnemies.ToArray();
        for(int i = 0; i < x.Length; i++)
        {
            x[i].Die();
        }
        spawnedEnemies = new List<Enemy>();
    }

    public IEnumerator GamePlayCoro()
    {
        yield return new WaitForSeconds(60f);
        maxEnemies =(int) (maxEnemies * 1.5);

        yield return new WaitForSeconds(120f);
        maxEnemies *= 2;

        yield return new WaitForSeconds(120f);
        maxEnemies = (int)(maxEnemies * 1.25);

        yield return new WaitForSeconds(120f);
        maxEnemies *= 2;

        yield return new WaitForSeconds(120f);
        maxEnemies *= 2;
    }


}

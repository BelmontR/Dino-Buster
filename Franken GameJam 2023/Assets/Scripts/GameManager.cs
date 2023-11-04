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
    }

    public void AddToScore(int increment)
    {
        score += increment;
    }

    public void IncrementKilledEnemies()
    {
        killedEnemies++;
    }



}

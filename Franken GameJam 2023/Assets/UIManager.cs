using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public UIHeart[] hearts;

    public GameObject gameOverScreen;

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

    }

    public void RemoveHeart()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (!hearts[i].grey)
            {
                hearts[i].BecomeGrey();
                i += 100;   //Beendet den Loop
            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

}

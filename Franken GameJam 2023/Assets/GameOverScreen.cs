using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI killedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        score.text = GameManager.instance.GetScore().ToString();
        killedEnemies.text = GameManager.instance.GetKE().ToString();
    }

}

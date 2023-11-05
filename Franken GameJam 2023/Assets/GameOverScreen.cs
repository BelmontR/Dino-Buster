using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI killedEnemies;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + GameManager.instance.GetScore().ToString();
        killedEnemies.text = "Busted Dinos: " + GameManager.instance.GetKE().ToString();

        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        while(music.volume > 0)
        {
            music.volume -= 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    /* static, damit es über Scenes hinweg erhalten bleibt.
     * Beim reinfaden beim Spielstart ist die Zeit für den Fade-In 2/1 = 1 */
    private static float transitionTime = 2;

    private Image panel;

    private bool fadingOut;
    private bool fadingIn;
    private string targetScene;

    private float transitionStartTimestamp;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        panel = GetComponent<Image>();

        // Fadet beim Lader der Scene rein
        transitionStartTimestamp = Time.time;
        fadingIn = true;
    }

    private void Update()
    {
        if (fadingOut)
        {
            Color col = panel.color;
            float progress = Mathf.Min((Time.time - transitionStartTimestamp) / (transitionTime / 2), 1);
            col.a = Mathf.Lerp(0, 1, progress);
            //Debug.Log($"Fading out, Time: {Time.time}, Progress: {progress}, Alpha: {col.a}");
            panel.color = col;

            if (progress >= 1)
            {
                fadingOut = false;

                SceneManager.LoadScene(targetScene);
            }
        }
        else if (fadingIn)
        {
            Color col = panel.color;
            float progress = Mathf.Max((Time.time - transitionStartTimestamp) / (transitionTime / 2), 0);
            col.a = Mathf.Lerp(1, 0, progress);
            //Debug.Log($"Fading in, Time: {Time.time}, Progress: {progress}, Alpha: {col.a}");
            panel.color = col;

            if (progress >= 1)
                fadingIn = false;
        }
    }

    /// <summary>
    /// Lädt die Scene <paramref name="scene"/> und fadet dabei ein und aus,
    /// was zusammen eine Zeit von <paramref name="transitionTime"/> dauert
    /// </summary>
    public void SwitchToScene(string scene)
    {
        this.targetScene = scene;
        transitionStartTimestamp = Time.time;
        fadingOut = true;
    }
}
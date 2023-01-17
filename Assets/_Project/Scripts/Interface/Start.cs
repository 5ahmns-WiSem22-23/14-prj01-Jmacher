using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    private void Awake()
    {
        float time = PlayerPrefs.GetFloat("scoreTime");
        if (time == 0) { tmp.text = ""; return; }

        string name = PlayerPrefs.GetString("scoreName");
        tmp.text = "current highscore by " + name + ": " + time.ToString("0.0") + "s";
    }

    public static void Play() => SceneManager.LoadScene(1);
    public static void Quit() => Application.Quit();

    [MenuItem("Game/Reset Score")]
    public static void ResetScore() => PlayerPrefs.SetFloat("scoreTime", 0);
}
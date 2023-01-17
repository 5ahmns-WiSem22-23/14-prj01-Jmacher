using TMPro;
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

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            PlayerPrefs.SetFloat("scoreTime", 0);
            tmp.text = "";
        }
    }

    public static void Play() => SceneManager.LoadScene(1);
    public static void Quit() => Application.Quit();
}
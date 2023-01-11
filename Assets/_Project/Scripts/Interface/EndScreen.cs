using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title, score, message;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private GameObject regularInterface, highscoreInterface, effectPrefab, player;
    [SerializeField] private Pause pause;

    private float scoreTime;
    private string[] endMessages = new string[]
    { "Stealing session finished!", "Present watering done!", "Christmas joy eliminated!", "Merry Wetness!" };

    public void CreateScreen(float time)
    {
        pause.enabled = false;

        scoreTime = time;
        bool highscore = time < PlayerPrefs.GetFloat("score");

        title.text = highscore ? "New Highscore!" : endMessages[Random.Range(0, endMessages.Length)];
        score.text = time.ToString("0.0");
        score.color = highscore ? new(.5f, .9f, .5f) : Color.white;
        regularInterface.SetActive(!highscore);
        highscoreInterface.SetActive(highscore);
        if (highscore) Instantiate(effectPrefab);

        player.SetActive(false);
    }

    public void Return() => SceneManager.LoadScene(0);
    public void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void Save()
    {
        //return if player presses twice
        if (PlayerPrefs.GetFloat("score") == scoreTime) return;

        string name = input.text.Replace(" ", "");

        //Check name
        if (name.Length < 3)
        {
            message.text = "The name must be at least 3 characters long and must not contain any spaces.";
            return;
        }

        message.text = "score saved!";
        input.text = "";

        //Save score
        PlayerPrefs.SetFloat("score", scoreTime);
        PlayerPrefs.SetString("score", name);
    }
}
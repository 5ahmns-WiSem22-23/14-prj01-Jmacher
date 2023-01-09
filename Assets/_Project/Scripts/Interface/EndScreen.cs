using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title, score, message;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private GameObject regularInterface, highscoreInterface, effectPrefab;

    private void CreateScreen(float score)
    {
        //Implement Highscore Check here

        title.text = true ? "New Highscore!" : "Game Over";
        this.score.text = score.ToString("0.0");
        regularInterface.SetActive(!true);
        highscoreInterface.SetActive(true);
        if (true) Instantiate(effectPrefab);
    }

    public void Return() => SceneManager.LoadScene(0);
    public void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void Save()
    {
        if (input.text.Length < 2)
        {
            message.text = "The name must be at least 2 characters long.";
            return;
        }
        if (input.text.Contains(" "))
        {
            message.text = "The name must not contain any spaces.";
            return;
        }
        //Check name against Database here

    }
}
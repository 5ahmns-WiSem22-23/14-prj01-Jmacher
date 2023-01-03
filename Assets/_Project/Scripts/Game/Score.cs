using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private int winCount;
    [Header("References")]
    [SerializeField] private GameObject gameInterface;
    [SerializeField]
    private GameObject endNormalInterface,
        endScoreInterface;
    [SerializeField]
    private TextMeshProUGUI countText,
        timeText,
        scoreText;

    private float time;

    private void Awake()
    {
        //Get initial win count
        Check();

        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        //Handle user interfaces
        gameInterface.SetActive(true);
        endNormalInterface.SetActive(false);
        endScoreInterface.SetActive(false);
    }

    private void Update()
    {
        //Reset Scene if backspace is pressed
        if (Input.GetKeyDown(KeyCode.Backspace)) Reload();

        //Count time
        time += Time.deltaTime;

        //Set time text
        timeText.text = time.ToString("0.0");
    }

    public bool Check()
    {
        //Set count text
        countText.text = transform.childCount + " / " + winCount;

        //Return if win count is not reached
        if (transform.childCount < winCount) return false;

        //Save time
        scoreText.text = time.ToString("0.0");

        //Show Endscreen
        gameInterface.SetActive(false);
        endNormalInterface.SetActive(true);

        //Enable cursor
        Cursor.lockState = CursorLockMode.None;

        return true;
    }

    public void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

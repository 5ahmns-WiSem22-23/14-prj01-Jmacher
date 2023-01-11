using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int winCount;

    [Header("References")]
    [SerializeField] private GameObject gameInterface, endInterface;
    [SerializeField] private TextMeshProUGUI countText, timeText;
    [SerializeField] private EndScreen screen;

    [HideInInspector] public float time;

    private void Awake()
    {
        //Set initial win count
        Check();

        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        //Handle user interfaces
        gameInterface.SetActive(true);
        endInterface.SetActive(false);
    }

    private void Update()
    {
        //Reset Scene if backspace is pressed
        if (Input.GetKeyDown(KeyCode.Backspace)) { /*Reset here*/ }

        //Count time
        time += Time.deltaTime;

        //Set time text
        timeText.text = time.ToString("0.0");
    }

    public bool Check()
    {
        //Set count text
        countText.text = (transform.childCount - 1).ToString() + " / " + winCount;

        //Return if win count is not reached
        if (transform.childCount - 1 < winCount) return false;

        //Show Endscreen
        gameInterface.SetActive(false);
        endInterface.SetActive(true);
        screen.CreateScreen(time);

        //Enable cursor
        Cursor.lockState = CursorLockMode.None;

        return true;
    }
}

using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int winCount;

    [Header("References")]
    [SerializeField] private GameObject gameInterface, endInterface;
    [SerializeField] private TextMeshProUGUI countText, timeText;
    [SerializeField] private EndScreen screen;
    [SerializeField] private Player player;

    [HideInInspector] public float time;

    private void Awake()
    {
        //Set initial win count
        _ = Check();

        Cursor.lockState = CursorLockMode.Locked;
        gameInterface.SetActive(true);
        endInterface.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) screen.Reload();

        time += Time.deltaTime;
        if (!player.started) time = 0;

        timeText.text = time.ToString("0.0");
    }

    public bool Check()
    {
        countText.text = (transform.childCount - 1).ToString() + " / " + winCount;

        if (transform.childCount - 1 < winCount) return false;

        gameInterface.SetActive(false);
        endInterface.SetActive(true);
        screen.CreateScreen(time);

        Cursor.lockState = CursorLockMode.None;
        Destroy(this);
        return true;
    }
}

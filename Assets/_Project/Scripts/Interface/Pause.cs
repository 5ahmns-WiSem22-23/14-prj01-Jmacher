using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private GameObject pauseInterface, gameInterface;
    [SerializeField] private Rigidbody2D player;
    private bool paused;
    private float time;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Exit();
            if (!paused) Enter();
        }
    }

    public void Exit()
    {
        paused = false;
        player.bodyType = RigidbodyType2D.Dynamic;
        pauseInterface.SetActive(false);
        gameInterface.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

        //Set time back to saved time
        score.time = time;
    }
    private void Enter()
    {
        //Collect time
        time = score.time;

        paused = true;
        player.bodyType = RigidbodyType2D.Static;
        pauseInterface.SetActive(true);
        gameInterface.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
}

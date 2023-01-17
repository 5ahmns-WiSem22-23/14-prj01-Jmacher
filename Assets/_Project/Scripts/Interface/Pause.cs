using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private GameObject pauseInterface, gameInterface;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private BoosterManager bm;
    [HideInInspector] public bool paused = false;
    private float time;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Toggle(!paused);
    }

    public void Toggle(bool state)
    {
        paused = state;

        if (state) time = score.time;
        else score.time = time;

        player.bodyType = state ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        pauseInterface.SetActive(state);
        gameInterface.SetActive(!state);
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        if (state) bm.StopAllCoroutines();
        else bm.Awake();
    }
}

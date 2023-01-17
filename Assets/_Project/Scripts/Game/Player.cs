using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10, boost = 5, duration = 3;
    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Pause pause;

    [HideInInspector] public bool started = false;

    private void FixedUpdate()
    {
        if (pause.paused) return;

        float mov = Input.GetAxis("Vertical") * speed;
        float rot = Input.GetAxis("Horizontal") * speed * .6f;

        if (!started)
        {
            if (mov != 0 || rot != 0) started = true;
        }

        rigidBody.velocity = transform.up * mov;
        rigidBody.SetRotation(rigidBody.rotation - rot);

        playerCamera.position = new(transform.position.x, transform.position.y, playerCamera.position.z);
    }

    public void Boost() => speed += boost;

    //Todo: fix boost duration
}
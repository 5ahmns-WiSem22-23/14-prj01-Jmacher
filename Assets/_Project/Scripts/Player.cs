using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1000, smooth = .1f;
    public Rigidbody2D rb;
    private Vector2 move, vel;

    private void FixedUpdate()
    {
        move = Vector2.SmoothDamp(move, speed * Vector3.Normalize(new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))), ref vel, smooth);
        rb.velocity = move;
    }
}
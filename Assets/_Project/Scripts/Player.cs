using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;

    private void Update()
    {
        Vector3 move = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(speed * Time.deltaTime * move.normalized);
    }

    //Fix stupid shit
}
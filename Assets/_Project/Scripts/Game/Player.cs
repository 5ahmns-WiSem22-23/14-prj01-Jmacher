using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10, boost = 5;
    [Header("References")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform playerCamera;

    private void FixedUpdate()
    {
        //Get the input for player movement and rotation
        float mov = Input.GetAxis("Vertical") * speed;
        float rot = Input.GetAxis("Horizontal") * speed * .6f;

        //Apply the movement and rotation to the player
        rigidBody.velocity = transform.up * mov;
        rigidBody.SetRotation(rigidBody.rotation - rot);

        //Assign the position of the player to the position of the camera
        playerCamera.position = new(transform.position.x, transform.position.y, playerCamera.position.z);
    }

    public void Boost() => speed += boost;
}
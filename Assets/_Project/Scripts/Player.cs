using UnityEngine;

public class Player : MonoBehaviour
{
    public float
        movementSpeed = 800,
        rotationSpeed = 400;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform playerCamera;

    private void Update()
    {
        //Get the input for player movement and rotation
        float rot = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float mov = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        //Apply the movement and rotation to the player
        rigidBody.velocity = transform.up * mov;
        rigidBody.SetRotation(rigidBody.rotation - rot);

        //Assign the position of the camera to the position of the player
        playerCamera.position = new(transform.position.x, transform.position.y, playerCamera.position.z);
    }
}
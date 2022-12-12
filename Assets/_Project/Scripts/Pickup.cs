using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float speed = 100;

    private bool carrying = false;

    void Update()
    {
        if (!carrying) transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            carrying = true;
        }
    }
}

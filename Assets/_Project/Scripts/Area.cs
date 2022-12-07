using UnityEngine;

public class Area : MonoBehaviour
{
    public PickupManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup")) collision.transform.SetParent(transform);
        manager.Spawn();
    }
}

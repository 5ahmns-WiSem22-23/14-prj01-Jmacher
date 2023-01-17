using UnityEngine;

public class Carrier : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PickupManager manager;
    [SerializeField] private Score score;

    private Pickup pickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup") && pickup == null)
        {
            if (other.GetComponent<Pickup>().collected) return;

            pickup = other.GetComponent<Pickup>();
            pickup.transform.SetParent(transform);
            pickup.transform.localPosition = new(0, .6f, 0);
            pickup.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Update()
    {
        if (score.GetComponent<BoxCollider2D>().bounds.Contains(transform.position) && pickup != null)
        {
            pickup.transform.SetParent(score.transform);

            if (score.Check())
            {
                Destroy(GetComponent<Player>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(this);
                return;
            }

            pickup.collected = true;

            Destroy(pickup.GetComponent<Collider2D>());
            pickup.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Background";
            pickup = null;

            manager.Spawn();
        }
    }
}

using UnityEngine;

public class Carrier : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PickupManager manager;
    [SerializeField] private Score score;

    private Pickup pickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the collider is a pickup and the carrier is empty
        if (other.CompareTag("Pickup") && pickup == null)
        {
            //Return if colliding pickup is collected
            if (other.GetComponent<Pickup>().collected) return;

            //Set pickup object to collider
            pickup = other.GetComponent<Pickup>();

            //Set pickup parent to carrier
            pickup.transform.SetParent(transform);

            //Reset pickup position and rotation
            pickup.transform.localPosition = new(0, .6f, 0);
            pickup.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Update()
    {
        //If the player is the dropoff zone and the carrier is not empty
        if (score.GetComponent<BoxCollider2D>().bounds.Contains(transform.position) && pickup != null)
        {
            //Set pickup parent to carrier
            pickup.transform.SetParent(score.transform);

            //Check win condition
            if (score.Check())
            {
                //Disable player
                Destroy(GetComponent<Player>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(this);
                return;
            }

            //Set pickup status to collected
            pickup.collected = true;

            //Remove the collider from the pickup
            Destroy(pickup.GetComponent<Collider2D>());

            //Set the pickup image sorting layer to the background
            pickup.GetComponent<SpriteRenderer>().sortingLayerName = "Background";

            //Set pickup variable to null
            pickup = null;

            //Spawn new pickup
            manager.Spawn();
        }
    }
}

using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject obstacle;
    public int distance = 20;
    public Pickup pickup;

    private void Awake() => Spawn();

    public void Spawn()
    {
        pickup = Instantiate(obstacle, transform).GetComponent<Pickup>();
        pickup.transform.position = new(Random.Range(-distance, distance), Random.Range(-distance, distance));
    }
}

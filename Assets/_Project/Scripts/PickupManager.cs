using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject obstacle;
    public int distance = 20;

    private void Awake() => Spawn();

    public void Spawn()
    {
        var obs = Instantiate(obstacle, transform);
        obs.transform.position = new(Random.Range(-distance, distance), Random.Range(-distance, distance));
    }
}

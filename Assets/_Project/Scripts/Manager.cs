using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject obstaclePrefab, pickupPrefab;
    public int size = 30;

    private GameObject pickup;
    public GameObject Pickup => pickup;

    private void Awake()
    {
        SpawnObstacles();
        SpawnPickup();
    }

    public void SpawnPickup()
    {
        pickup = Instantiate(pickupPrefab, GetPosition(), Quaternion.identity);

        Vector3 GetPosition()
        {
            Vector3 position = new(Random.Range(-size, size), Random.Range(-size, size));

            foreach (Transform obstacle in transform)
            {
                if (obstacle.GetComponent<BoxCollider2D>().bounds.Contains(position)) return GetPosition();
            }

            return position;
        }
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < size; i++)
        {
            Vector3 pos = new(Random.Range(-size, size), Random.Range(-size, size));
            Vector3 scale = new(Random.Range(1, 10), Random.Range(1, 10));

            int[] angles = new int[8] { 0, 45, 90, 135, 180, 225, 270, 315 };
            Vector3 rot = new(0, 0, angles[Random.Range(0, 8)]);

            Instantiate(obstaclePrefab, pos, Quaternion.Euler(rot), transform).transform.localScale = scale;
        }
    }
}

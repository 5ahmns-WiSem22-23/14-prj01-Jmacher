using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    [SerializeField] private GameObject[] spawnPoints;

    public Transform Pickup { get; private set; }

    private void Awake() => Spawn();

    public void Spawn()
    {
        //Return if spawn points are not set
        if (spawnPoints.Length < 1)
        {
            print("Pickup spawnpoints are missing");
            return;
        }

        //Spawn pickup at one of the spawnpoints
        Pickup = Instantiate(pickupPrefab, spawnPoints[Random.Range(0, spawnPoints.Length - 1)].transform.position, Quaternion.identity).transform;
    }
}

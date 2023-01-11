using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] pickupPrefabs = new GameObject[3];
    [SerializeField] private bool debugPoints;
    private List<Transform> spawnPoints = new();

    public Transform Pickup { get; private set; }

    private void Awake()
    {
        GetPoints();
        Spawn();
    }

    public void Spawn()
    {
        //Return if spawn points are not set
        if (spawnPoints.Count < 1) return;

        //Spawn pickup at one of the spawnpoints
        Pickup = Instantiate(pickupPrefabs[Random.Range(0, 3)], spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity).transform;

        //Rotate pickup randomly
        Pickup.Rotate(0, 0, Random.Range(0, 360));
    }

    public void GetPoints()
    {
        //Get spawn points from children transform
        spawnPoints = GetComponentsInChildren<Transform>().ToList();
        //Remove parent transform from list
        spawnPoints.Remove(transform);
    }

    private void OnDrawGizmos()
    {
        GetPoints();

        //Return if debug points are not set
        if (!debugPoints) return;
        if (spawnPoints.Count < 1) return;

        //Draw Debug Gizmos
        Gizmos.color = Color.red;
        foreach (Transform point in spawnPoints) Gizmos.DrawSphere(point.transform.position, .2f);
    }
}

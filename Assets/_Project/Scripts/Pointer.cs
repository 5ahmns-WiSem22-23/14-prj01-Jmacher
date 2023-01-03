using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private int distance = 5;
    [Header("References")]
    [SerializeField] private PickupManager manager;

    private void Update()
    {
        //Return if current pickup is not set
        if (manager.Pickup == null) return;

        //Get current pickup
        Transform pickup = manager.Pickup;

        //Set pointer active depending on distance
        transform.GetChild(0).gameObject.SetActive(Vector3.Distance(transform.position, pickup.position) > distance);

        //Rotate transform towards pickup
        Vector3 dir = pickup.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

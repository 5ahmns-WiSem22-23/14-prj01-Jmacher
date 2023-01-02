using UnityEngine;

public class Pointer : MonoBehaviour
{
    public int distance = 5;
    public PickupManager manager;

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

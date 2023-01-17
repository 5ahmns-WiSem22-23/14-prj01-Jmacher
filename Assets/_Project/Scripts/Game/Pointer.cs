using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private int distance = 5;
    [Header("References")]
    [SerializeField] private PickupManager manager;

    private void Update()
    {
        if (manager.Pickup == null) return;

        Transform pickup = manager.Pickup;
        transform.GetChild(0).gameObject.SetActive(Vector3.Distance(transform.position, pickup.position) > distance);

        Vector3 dir = pickup.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

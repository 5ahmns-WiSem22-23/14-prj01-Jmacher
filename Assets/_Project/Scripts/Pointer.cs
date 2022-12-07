using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public PickupManager pm;
    public float distance = 4;

    private Transform pickup;

    private void Update()
    {
        pickup = pm.pickup.transform;

        Image img = GetComponentInChildren<Image>();
        img.enabled = Vector3.Distance(transform.position, pickup.position) > distance;

        Vector3 dir = pickup.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

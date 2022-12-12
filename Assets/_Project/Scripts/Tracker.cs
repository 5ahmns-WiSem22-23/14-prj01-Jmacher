using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Transform player;
    public float smooth;
    private Vector2 pos;

    void FixedUpdate()
    {
        pos = Vector2.Lerp(pos, player.transform.position, smooth);
        transform.position = new Vector3(pos.x, pos.y, -10);
    }
}
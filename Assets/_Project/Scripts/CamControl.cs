using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform player;
    public float smooth;

    private void LateUpdate()
    {
        var pos = Vector2.Lerp(transform.position, player.position, smooth);
        transform.position = new Vector3(pos.x, pos.y, -10);
    }
}

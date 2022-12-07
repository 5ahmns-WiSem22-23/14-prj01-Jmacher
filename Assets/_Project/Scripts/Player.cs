using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;

    private void LateUpdate()
    {
        Vector3 move = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += speed * Time.deltaTime * move.normalized;
    }
}

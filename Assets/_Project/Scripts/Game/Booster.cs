using UnityEngine;

public class Booster : MonoBehaviour
{
    public float speed = 5f;
    private BoosterManager bm;

    private void Awake() => bm = FindObjectOfType<BoosterManager>();
    private void Update() => transform.Rotate(0, 0, speed);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Boost();
            bm.boosters.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

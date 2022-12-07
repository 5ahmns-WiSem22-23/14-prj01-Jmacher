using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    public int distance = 20;
    public int count = 10;

    private void Awake()
    {
        for (int i = 0; i < count; i++)
        {
            var obs = Instantiate(obstacle, transform);

            obs.transform.position = new(Random.Range(-distance, distance), Random.Range(-distance, distance));
            obs.transform.localScale = new(Random.Range(1, 5), Random.Range(1, 5));
        }
    }
}

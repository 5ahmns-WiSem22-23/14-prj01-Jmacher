using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    public int distance = 20;
    public int count = 10;
    private float[] angles = new float[8] { 0, 45, 90, 135, 180, 225, 270, 315 };

    private void Awake() => Spawn();

    public void Spawn()
    {

        for (var i = 0; i < count; i++)
        {
            GameObject obs = Instantiate(obstacle, transform);

            obs.transform.position = new(Random.Range(-distance, distance), Random.Range(-distance, distance));
            obs.transform.localScale = new(Random.Range(1, 10), Random.Range(1, 10));
            obs.transform.Rotate(new(0, 0, angles[Random.Range(0, 8)]));
        }
    }
}

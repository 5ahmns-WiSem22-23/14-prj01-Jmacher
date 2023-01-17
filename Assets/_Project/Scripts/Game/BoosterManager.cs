using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoosterManager : MonoBehaviour
{
    public int max = 3;
    [SerializeField] private GameObject boosterPrefab;
    [SerializeField] private bool debugPoints;

    [HideInInspector] public List<GameObject> boosters = new();
    private List<Transform> spawnPoints = new();

    public void Awake() => StartCoroutine(SpawnBooster());

    public IEnumerator SpawnBooster()
    {
        spawnPoints = GetComponentsInChildren<Transform>().ToList();
        spawnPoints.Remove(transform);

        while (boosters.Count < max)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));

            GameObject boost = Instantiate(boosterPrefab);
            boost.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            boost.transform.Rotate(0, 0, Random.Range(0, 360));

            boosters.Add(boost);
        }
    }

    private void OnDrawGizmos()
    {
        if (!debugPoints) return;

        spawnPoints = GetComponentsInChildren<Transform>().ToList();
        spawnPoints.Remove(transform);

        Gizmos.color = Color.blue;
        foreach (Transform child in spawnPoints) Gizmos.DrawSphere(child.position, .2f);
    }
}
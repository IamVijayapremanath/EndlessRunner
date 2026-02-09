using UnityEngine;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle_prefab;
    public Transform Player;
    public float spawn_distance = 20f;
    public float spawn_interval = 1.5f;
    public float cleanup_distance = 15f; 

    private float[] lanes = { -3f, 0f, 3f };
    private float timer;

    private List<GameObject> activeObstacles = new List<GameObject>();

    void Update()
    {
        
        if (Player == null) return;

        timer += Time.deltaTime;

        if (timer >= spawn_interval)
        {
            SpawnObstaclePattern();
            timer = 0;
        }
        for (int i = activeObstacles.Count - 1; i >= 0; i--)
        {
            if (activeObstacles[i] != null)
            {
                if (activeObstacles[i].transform.position.z < Player.position.z - cleanup_distance)
                {
                    GameObject obsToDelete = activeObstacles[i];
                    activeObstacles.RemoveAt(i);
                    Destroy(obsToDelete);
                }
            }
            else
            {
                activeObstacles.RemoveAt(i);
            }
        }
    }

    void SpawnObstaclePattern()
    {
        int numToSpawn = Random.Range(1, 3);
        int firstLaneIndex = Random.Range(0, lanes.Length);

        SpawnAtPosition(lanes[firstLaneIndex]);

        if (numToSpawn == 2)
        {
            int secondLaneIndex = (firstLaneIndex + Random.Range(1, 3)) % lanes.Length;
            SpawnAtPosition(lanes[secondLaneIndex]);
        }
    }

    void SpawnAtPosition(float xPos)
    {
        Vector3 spawnPos = new Vector3(xPos, 1f, Player.position.z + spawn_distance);
        GameObject newObstacle = Instantiate(obstacle_prefab, spawnPos, Quaternion.identity);
        activeObstacles.Add(newObstacle);
    }
}
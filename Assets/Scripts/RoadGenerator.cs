using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoadGenerator : MonoBehaviour
{
    public GameObject startRoadTile;
    public GameObject[] roadPrefabs;
    private List<GameObject> activeRoads = new List<GameObject>();
    private float newRoadPositionZ = 0;
    private float roadLength = 20;
    private GameObject road;
    private int roadCount;

    [SerializeField] private Transform player;
    private int startCountRoad = 6;

    private void Start()
    {
        for (int i = 0; i < startCountRoad; i++)
        {
            CreatNextRoad(Random.Range(0, roadPrefabs.Length));
        }
    }

    private void Update()
    {
        if (player.position.z - roadLength/1.2f > newRoadPositionZ - (startCountRoad * roadLength))
        {
            CreatNextRoad(Random.Range(0, roadPrefabs.Length));
            DestroyRoad();
        }
    }

    void CreatNextRoad(int roadIndex)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + newRoadPositionZ);

        if (roadCount <= 0)
        {
            road = startRoadTile;
        }

        else
        {
            road = roadPrefabs[roadIndex];
        }

        GameObject nextRoad = Instantiate(road,pos , transform.rotation);
        activeRoads.Add(nextRoad);
        newRoadPositionZ += roadLength;
        roadCount++;
    }

    void DestroyRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

}

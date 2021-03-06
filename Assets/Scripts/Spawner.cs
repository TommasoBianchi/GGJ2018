﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int amountOfPeopleToSpawn;
    public GameObject[] peoplePrefabs;

    public int amountOfVehiclesToSpawn;
    public GameObject[] vehiclePrefabs;

    public float percentageOfObstaclesToRemove = 0;
    
	void Start ()
    {
        Waypoint[] peopleWaypoints = FindObjectsOfType<CrowdWaypoint>();
        for (int i = 0; i < amountOfPeopleToSpawn; i++)
        {
            Waypoint waypoint = peopleWaypoints[Random.Range(0, peopleWaypoints.Length)];
            GameObject prefab = peoplePrefabs[Random.Range(0, peoplePrefabs.Length)];
            GameObject go = Instantiate(prefab, waypoint.transform.position, Quaternion.identity);
            go.GetComponent<Mover>().SetWaypoint(waypoint);
        }

        Waypoint[] vehicleWaypoints = FindObjectsOfType<TrafficWaypoint>();
        // Shuffle the vehicle waypoints (Fisher-Yates)
        for (int i = vehicleWaypoints.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);
            Waypoint tmp = vehicleWaypoints[i];
            vehicleWaypoints[i] = vehicleWaypoints[j];
            vehicleWaypoints[j] = tmp;
        }
        for (int i = 0; i < amountOfVehiclesToSpawn && i < vehicleWaypoints.Length; i++)
        {
            Waypoint waypoint = vehicleWaypoints[i];
            GameObject prefab = vehiclePrefabs[Random.Range(0, vehiclePrefabs.Length)];
            GameObject go = Instantiate(prefab, waypoint.transform.position, Quaternion.identity);
            go.GetComponent<VehicleMover>().SetWaypoint(waypoint);
        }

        ActivateObstacole[] obstacles = FindObjectsOfType<ActivateObstacole>();
        // Shuffle the obstacles (Fisher-Yates)
        for (int i = obstacles.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);
            ActivateObstacole tmp = obstacles[i];
            obstacles[i] = obstacles[j];
            obstacles[j] = tmp;
        }
        int obstaclesToRemove = Mathf.FloorToInt(obstacles.Length * percentageOfObstaclesToRemove);
        for (int i = 0; i < obstaclesToRemove && i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int amountToSpawn;
    public GameObject[] prefabsToSpawn;
    
	void Start ()
    {
        Waypoint[] waypoints = FindObjectsOfType<CrowdWaypoint>();
        for (int i = 0; i < amountToSpawn; i++)
        {
            Waypoint waypoint = waypoints[Random.Range(0, waypoints.Length)];
            GameObject prefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
            GameObject go = Instantiate(prefab, waypoint.transform.position, Quaternion.identity);
            go.GetComponent<PersonMover>().SetWaypoint(waypoint);
        }	
	}
}

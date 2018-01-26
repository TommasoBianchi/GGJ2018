using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMover : MonoBehaviour {

    private float speedMean = 2f;
    private float speedVariance = 0.2f;

    private float speed = 1f;
    private Waypoint currentWaypoint;
    
	void Start ()
    {
        // TESTING
        SetWaypoint(FindObjectOfType<CrowdWaypoint>());
        // TESTING
    }

    void Update ()
    {
        if ((transform.position - currentWaypoint.transform.position).sqrMagnitude < 0.6f * 0.6f)
        {
            UpdateWaypoint();
        }

        Vector3 dir = (currentWaypoint.transform.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void UpdateWaypoint()
    {
        Waypoint newWaypoint = currentWaypoint.neighbours[Random.Range(0, currentWaypoint.neighbours.Length)];
        speed = GaussianDistribution.Generate(speedMean, speedVariance);
    }

    public void SetWaypoint(Waypoint waypoint)
    {
        currentWaypoint = waypoint;
        if((transform.position - waypoint.transform.position).sqrMagnitude < Mathf.Epsilon)
        {
            UpdateWaypoint();
        }
    }
}

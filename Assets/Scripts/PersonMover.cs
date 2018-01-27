using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMover : MonoBehaviour {

    private float speedMean = 1f;
    private float speedVariance = 0.05f;

    private float speed = 1f;
    private float turningSpeed = 500f;
    private Waypoint currentWaypoint;
    
	void Start ()
    {

    }

    void Update ()
    {
        if ((transform.position - currentWaypoint.transform.position).sqrMagnitude < 0.1f * 0.1f)
        {
            UpdateWaypoint();
        }

        Vector3 dir = (currentWaypoint.transform.position - transform.position).normalized;
        float angle = Vector2.SignedAngle(transform.right, dir);
        if (angle > 0)
        {
            transform.Rotate(0, 0, Mathf.Min(turningSpeed * Time.deltaTime, angle));
        }
        else
        {
            transform.Rotate(0, 0, Mathf.Max(-turningSpeed * Time.deltaTime, angle));
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    private void UpdateWaypoint()
    {
        currentWaypoint = currentWaypoint.neighbours[Random.Range(0, currentWaypoint.neighbours.Length)];
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

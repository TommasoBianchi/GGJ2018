using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    
    public Waypoint[] neighbours;
    public Color color = Color.black;

    void Start()
    {

    }

    void OnDrawGizmos()
    {

        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position - Vector3.forward * 5, 0.2f);
        for (int i = 0; neighbours != null && i < neighbours.Length; i++)
        {
            if (neighbours[i] != null)
            {
                Vector3 dir = (neighbours[i].transform.position - transform.position).normalized;
                Vector3 rightDir = Quaternion.Euler(0, 0, 90) * dir;
                Gizmos.DrawLine(transform.position + rightDir * 0.05f - Vector3.forward * 5,
                                neighbours[i].transform.position + rightDir * 0.05f - Vector3.forward * 5);
            }
        }
    }

    public virtual void WaypointReached(PersonMover mover)
    {
        
    }
}

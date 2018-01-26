using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint[] neighbours;

    private Color color = Color.black;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 200);
        for (int i = 0; neighbours != null && i < neighbours.Length; i++)
        {
            if(neighbours[i] != null)
                Gizmos.DrawLine(transform.position, neighbours[i].transform.position);
        }
    }
}

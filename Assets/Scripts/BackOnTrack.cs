using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOnTrack : MonoBehaviour {

    public LayerMask pavement;
    private Vector3 rightWay;

    protected float speed = 1f;
    protected float turningSpeed = 500f;

    // Use this for initialization
    void Start () {
        rightWay = FindTheWay();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private Vector3 FindTheWay ()
    {
        RaycastHit2D[] ray = new RaycastHit2D[8];
        Vector2 way = new Vector2 (0,0);
        float distance = Mathf.Infinity;
        
        //shoot lazers everywhere
        ray[0] = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, pavement);
        ray[1] = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, pavement);
        ray[2] = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, pavement);
        ray[3] = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, pavement);
        ray[4] = Physics2D.Raycast(transform.position, new Vector2 (1,1), Mathf.Infinity, pavement);
        ray[5] = Physics2D.Raycast(transform.position, new Vector2(1, -1), Mathf.Infinity, pavement);
        ray[6] = Physics2D.Raycast(transform.position, new Vector2(-1, 1), Mathf.Infinity, pavement);
        ray[7] = Physics2D.Raycast(transform.position, new Vector2(-1, -1), Mathf.Infinity, pavement);

        for (int i=0;i<8;i++)
        {
            if (ray[i].distance < distance)
            {
                way = ray[i].point;
                distance = ray[i].distance;
            }
        }
        return (way);
    }

    protected void Move()
    {
        Vector3 dir = (rightWay - transform.position).normalized;
        float angle = Vector2.SignedAngle(transform.right, dir);
        if (angle > 0)
        {
            transform.Rotate(0, 0, Mathf.Min(turningSpeed * Time.deltaTime, angle));
        }
        else
        {
            transform.Rotate(0, 0, Mathf.Max(-turningSpeed * Time.deltaTime, angle));
        }

        if ((transform.position - rightWay).sqrMagnitude < 0.1f * 0.1f)
        {
            //UpdateWaypoint();
            gameObject.GetComponent<Mover>().enabled = true;
            gameObject.GetComponent<BackOnTrack>().enabled = false;
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
}

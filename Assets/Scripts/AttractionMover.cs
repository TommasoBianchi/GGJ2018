﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionMover : MonoBehaviour {

    public Vector3 attractorLocation;
    public int croudArea;

    private Vector3 dir;
    private bool arrived;

    protected float turningSpeed = 500f;
    protected float speed = 1f;

    void Start () {
        arrived = false;   
	}

    private void Update()
    {
        if (!arrived)
        {
            Move();
        }
    }

    protected void Move()
    {
        Vector3 dir = (attractorLocation - transform.position).normalized;
        float angle = Vector2.SignedAngle(transform.right, dir);
        if (angle > 0)
        {
            transform.Rotate(0, 0, Mathf.Min(turningSpeed * Time.deltaTime, angle));
        }
        else
        {
            transform.Rotate(0, 0, Mathf.Max(-turningSpeed * Time.deltaTime, angle));
        }

        if ((transform.position - attractorLocation).sqrMagnitude <= croudArea )
        {
            arrived = true;
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMover : Mover {

    [Range(1, 20)]
    public int raycastPerSecond;
    public LayerMask raycastLayerMask;

    private float nextRaycastTime;

    private float acceleration = 5f;
    private float maxSpeed = 5f;
    
	void Start ()
    {
        speedMean = 5f;
        speedVariance = 0f;

        speed = 0f;
        turningSpeed = 1500f;

        randomizeSpeed = false;

        SetCanMove(true);
        randomTargetDisplacement = false;

        nextRaycastTime = Time.time + 1.0f / raycastPerSecond;
    }
	
	void Update ()
    {
        if (Time.time > nextRaycastTime)
        {
            RaycastCollisions();
            nextRaycastTime = Time.time + 1.0f / raycastPerSecond;
        }

        if (acceleration > 0 && speed < maxSpeed)
        {
            speed += Mathf.Min(0.8f *acceleration * Time.deltaTime, maxSpeed - speed);
        }
        else if (acceleration < 0 && speed > 0)
        {
            Brake(3);
        }

        Move();
	}

    void RaycastCollisions()
    {
        Vector2 origin = transform.position + transform.right * 1;
        Vector2[] directions =
        {
            transform.right,
            Quaternion.Euler(0, 0, 10) * transform.right,
            Quaternion.Euler(0, 0, -10) * transform.right,
            Quaternion.Euler(0, 0, 20) * transform.right,
            Quaternion.Euler(0, 0, -20) * transform.right
        };
        float[] distances = { 1.5f, 1f, 1f, 1f, 1f };

        for (int i = 0; i < directions.Length; i++)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(origin, directions[i], 1.5f, raycastLayerMask);
            if (hitInfo.collider != null)
            {
                acceleration = -Mathf.Abs(acceleration);
                Brake(1 / hitInfo.distance);
                return;
            }
        }

        acceleration = Mathf.Abs(acceleration);

        /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position + transform.right * 1, transform.right, 1.5f, raycastLayerMask);
        if(hitInfo.collider != null)
        {
            acceleration = -Mathf.Abs(acceleration);
            Brake(1 / hitInfo.distance);
        }
        else
        {
            hitInfo = Physics2D.Raycast(transform.position + transform.right * 1, Quaternion.Euler(0, 0, 10) * transform.right, 0.8f, raycastLayerMask);
            if (hitInfo.collider != null)
            {
                acceleration = -Mathf.Abs(acceleration);
                Brake(1 / hitInfo.distance);
            }
            else
            {
                hitInfo = Physics2D.Raycast(transform.position + transform.right * 1, Quaternion.Euler(0, 0, -10) * transform.right, 0.8f, raycastLayerMask);
                if (hitInfo.collider != null)
                {
                    acceleration = -Mathf.Abs(acceleration);
                    Brake(1 / hitInfo.distance);
                }
                else
                {
                    acceleration = Mathf.Abs(acceleration);
                }
            }
        }*/
    } 

    private void Brake(float strength)
    {
        speed -= Mathf.Min(-strength * acceleration * Time.deltaTime, speed);
    }
}

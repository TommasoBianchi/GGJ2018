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

    private float maxTimeWaiting = 25;
    private float timeWaiting = 0;
    private bool canRaycast = true;
    
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
        if (canRaycast && Time.time > nextRaycastTime)
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
        timeWaiting += 1.0f / raycastPerSecond;
        if (timeWaiting > maxTimeWaiting)
        {
            Debug.LogWarning("Vehicle " + name + " has been found to be stuck (deadlocked). Now ignoring collisions.");
            acceleration = Mathf.Abs(acceleration);
            canRaycast = false;
            new System.Threading.Thread(() => {
                System.Threading.Thread.Sleep(10 * 1000); // Wait ten seconds
                canRaycast = true;
                timeWaiting = 0;
            }).Start();
            return;
        }

        Vector2 origin = transform.position + transform.right * 1.2f;
        Vector2[] directions =
        {
            transform.right,
            Quaternion.Euler(0, 0, 10) * transform.right,
            Quaternion.Euler(0, 0, -10) * transform.right,
            Quaternion.Euler(0, 0, 20) * transform.right,
            Quaternion.Euler(0, 0, -20) * transform.right
        };
        float[] distances = { 1.5f, 1f, 1f, 0.6f, 0.6f };

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

        timeWaiting = 0;
        acceleration = Mathf.Abs(acceleration);
    } 

    private void Brake(float strength)
    {
        speed -= Mathf.Min(-strength * acceleration * Time.deltaTime, speed);
    }
}

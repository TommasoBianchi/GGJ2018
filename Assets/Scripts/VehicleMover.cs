using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMover : Mover {

    [Range(1, 20)]
    public int raycastPerSecond;
    public LayerMask raycastLayerMask;

    private float nextRaycastTime;
    
	void Start ()
    {
        speedMean = 5f;
        speedVariance = 0.5f;

        speed = 5f;
        turningSpeed = 1000f;

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

        Move();
	}

    void RaycastCollisions()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position + transform.right * 1, transform.right, 0.5f, raycastLayerMask);
        if(hitInfo.collider != null)
        {
            SetCanMove(false);
        }
        else
        {
            hitInfo = Physics2D.Raycast(transform.position + transform.right * 1, Quaternion.Euler(0, 0, 10) * transform.right, 0.5f, raycastLayerMask);
            if (hitInfo.collider != null)
            {
                SetCanMove(false);
            }
            else
            {
                hitInfo = Physics2D.Raycast(transform.position + transform.right * 1, Quaternion.Euler(0, 0, -10) * transform.right, 0.5f, raycastLayerMask);
                if (hitInfo.collider != null)
                {
                    SetCanMove(false);
                }
                else
                {
                    SetCanMove(true);
                }
            }
        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Bounds cameraWorldBounds;
    public float speed;
    public Bounds screenBounds;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition.x /= Screen.width;
        mousePosition.y /= Screen.height;

		if (!screenBounds.Contains(mousePosition))
        {
            if (mousePosition.x >= screenBounds.max.x)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
            else if (mousePosition.x <= screenBounds.min.x)
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }

            if (mousePosition.y >= screenBounds.max.y)
            {
                transform.Translate(transform.up * speed * Time.deltaTime);
            }
            else if (mousePosition.y <= screenBounds.min.y)
            {
                transform.Translate(-transform.up * speed * Time.deltaTime);
            }
        }

        if (!cameraWorldBounds.Contains(transform.position))
        {
            float minDist = cameraWorldBounds.SqrDistance(transform.position);
            Vector3 closestPoint = cameraWorldBounds.ClosestPoint(transform.position);
            closestPoint.z = transform.position.z;
            Vector3 dir = (closestPoint - transform.position).normalized;
            transform.Translate(minDist * dir * speed * Time.deltaTime);
        }
    }
}

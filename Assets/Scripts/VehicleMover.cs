using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMover : Mover {
    
	void Start ()
    {
        speedMean = 5f;
        speedVariance = 0.5f;

        speed = 5f;
        turningSpeed = 1000f;

        SetCanMove(true);
        randomTargetDisplacement = false;
    }
	
	void Update ()
    {
        Move();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSemaphoreWaypoint : Waypoint {

    public Semaphore.SemaphoreType semaphoreType;

    public Semaphore semaphore;

    private Queue<PersonMover> queuedPeople;

    void Start()
    {
        queuedPeople = new Queue<PersonMover>();
        if (semaphoreType == Semaphore.SemaphoreType.Horizontal)
        {
            semaphore.OnSemaphoreHorizontalGreen += DequeuePeople;
        }
        else
        {
            semaphore.OnSemaphoreVerticalGreen += DequeuePeople;
        }
    }

    private void DequeuePeople()
    {
        while(queuedPeople.Count > 0)
        {
            queuedPeople.Dequeue().SetCanMove(true);
        }
    }

    void Update ()
    {
		
	}

    public override void WaypointReached(PersonMover mover)
    {
        base.WaypointReached(mover);
        
        if(semaphore.greenSemaphore == semaphoreType)
        {
            // Do Nothing, mover can cross the street
        }
        else
        {
            mover.SetCanMove(false);
            queuedPeople.Enqueue(mover);
        }
    }
}

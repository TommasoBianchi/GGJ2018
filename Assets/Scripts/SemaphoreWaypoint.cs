using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaphoreWaypoint : Waypoint {

    public Semaphore.SemaphoreType semaphoreType;

    public Semaphore semaphore;

    private Queue<Mover> queuedMovers;

    void Start()
    {
        queuedMovers = new Queue<Mover>();
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
        while(queuedMovers.Count > 0)
        {
            queuedMovers.Dequeue().SetCanMove(true);
        }
    }

    void Update ()
    {
		
	}

    public override void WaypointReached(Mover mover)
    {
        base.WaypointReached(mover);
        
        if(semaphore.greenSemaphore == semaphoreType)
        {
            // Do Nothing, mover can cross the street
        }
        else
        {
            mover.SetCanMove(false);
            queuedMovers.Enqueue(mover);
        }
    }
}

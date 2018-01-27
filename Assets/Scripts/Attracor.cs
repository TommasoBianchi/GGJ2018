using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracor : MonoBehaviour {

    public float range;
    public float duraionMin;
    public float durationMax;

    private Collider2D[] Neighbours;
    private bool influencing;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        WhoIsAroud();
        influencing = true;
        startTime = Time.time;
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void WhoIsAroud ()
    {
        Vector2 here = transform.position;
        Neighbours = Physics2D.OverlapCircleAll(here, range);
    }

    private void SetMode()
    {
        int i;

        if (influencing)
        {
            for(i=0;i<Neighbours.Length;i++)
            {
                //Aggiungere Behaviour in base al tipo di tizio/Power
                //Neighbours[i].GetComponent<Pathfinding>.setActive(false);
            }
        }

        else
        {
            for (i = 0; i < Neighbours.Length; i++)
            {
                //Neighbours[i].GetComponent<Pathfinding>.setActive(true);
            }
        }
    }
}

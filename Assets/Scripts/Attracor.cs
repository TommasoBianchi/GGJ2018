using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracor : MonoBehaviour {

    public float range;
    public float duration;
    public int type;
    public int skillType;

    private Collider2D[] Neighbours;
    private bool influencing;
    private float startTime;
    private string attractive;
    private string repulsive;

    private GameManager.PersonType personType;

    // Use this for initialization
    void Start()
    {
        WhoAmI();
        influencing = true;
        startTime = Time.time;
        Activate();
        SFXManager.Instance.PlaySample(1);
    }

	// Update is called once per frame
	void Update () {
		if (startTime+duration<=Time.time)
        {
            influencing = false;
            SetMode();
        }
	}

    private void Activate ()
    {
        WhoIsAroud();
        SetMode();
        ActivateObstacles();
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
                if (skillType == 3)
                {
                    Neighbours[i].GetComponent<Mover>().enabled = false;
                    Neighbours[i].GetComponent<BackOnTrack>().enabled = false;
                    Neighbours[i].GetComponent<AttractionMover>().enabled = true;
                    Neighbours[i].GetComponent<AttractionMover>().attractorLocation = transform.position;
                    Neighbours[i].GetComponent<AttractionMover>().attraction = true;
                    Neighbours[i].gameObject.layer = LayerMask.NameToLayer("AttractedPerson");
                    continue;
                }
                
                if (Neighbours[i].tag == attractive)
                {
                    Neighbours[i].GetComponent<Mover>().enabled = false;
                    Neighbours[i].GetComponent<BackOnTrack>().enabled = false;
                    Neighbours[i].GetComponent<AttractionMover>().enabled = true;
                    Neighbours[i].GetComponent<AttractionMover>().attractorLocation = transform.position;
                    Neighbours[i].GetComponent<AttractionMover>().attraction = true;
                    Neighbours[i].gameObject.layer = LayerMask.NameToLayer("AttractedPerson");
                }
                else if (Neighbours[i].tag == repulsive)
                {
                    Neighbours[i].GetComponent<Mover>().enabled = false;
                    Neighbours[i].GetComponent<BackOnTrack>().enabled = false;
                    Neighbours[i].GetComponent<AttractionMover>().enabled = true;
                    Neighbours[i].GetComponent<AttractionMover>().attractorLocation = transform.position;
                    Neighbours[i].GetComponent<AttractionMover>().attraction = false;
                    Neighbours[i].gameObject.layer = LayerMask.NameToLayer("AttractedPerson");
                }
            }
        }

        else
        {
            for (i = 0; i < Neighbours.Length; i++)
            {
                if (Neighbours[i] == null)
                {
                    continue;
                }
                else
                {
                    if (Neighbours[i].tag == attractive || Neighbours[i].tag == repulsive)
                    {
                        Neighbours[i].GetComponent<BackOnTrack>().enabled = true;
                        Neighbours[i].GetComponent<AttractionMover>().enabled = false;
                        Neighbours[i].gameObject.layer = LayerMask.NameToLayer("Person");
                    }
                    if (skillType == 3)
                    {
                        Neighbours[i].GetComponent<BackOnTrack>().enabled = true;
                        Neighbours[i].GetComponent<AttractionMover>().enabled = false;
                        Neighbours[i].gameObject.layer = LayerMask.NameToLayer("Person");
                    }
                }
            }

            DeactivateObstacles();

            Destroy(gameObject);
        }
    }

    private void WhoAmI ()
    {
        if (type == 1)
        {
            attractive = "gamer";
            repulsive = "fashion";
            personType = GameManager.PersonType.Gamer;
        }
        else if (type == 2)
        {
            attractive = "fashion";
            repulsive = "sport";
            personType = GameManager.PersonType.Girl;
        }
        else
        {
            attractive = "sport";
            repulsive = "gamer";
            personType = GameManager.PersonType.Sportman;
        }

        if (skillType == 1)
        {
            range = 5;
            duration = 5;
        }
        else if (skillType == 2)
        {
            range = 12;
            duration = 8;
            GameManager.ConsumeKillPoints(personType);
        }
        else
        {
            range = 20;
            duration = 10;
        }
    }
    private void ActivateObstacles()
    {
        for (int i = 0; i < Neighbours.Length; i++)
        {
            if (Neighbours[i] == null) continue;

            ActivateObstacole obstacle = Neighbours[i].GetComponent<ActivateObstacole>();
            if (obstacle != null)
            {
                obstacle.Activate();
            }
        }
    }

    private void DeactivateObstacles()
    {
        for (int i = 0; i < Neighbours.Length; i++)
        {
            if (Neighbours[i] == null) continue;

            ActivateObstacole obstacle = Neighbours[i].GetComponent<ActivateObstacole>();
            if (obstacle != null)
            {
                obstacle.Deactivate();
            }
        }
    }
}

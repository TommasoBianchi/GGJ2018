using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pavement : MonoBehaviour {

    public GameObject hydrantPrefab;
    public GameObject wastebinPrefab;

    private Bounds outerBound;
    private Bounds innerBound;

	void Start ()
    {
        outerBound = new Bounds(transform.position, new Vector3(8.8f, 8.8f, 100));
        innerBound = new Bounds(transform.position, new Vector3(6.8f, 6.8f, 100));

        Instantiate(hydrantPrefab, RandomPosition(), RandomRotation()).transform.parent = transform;
        Instantiate(wastebinPrefab, RandomPosition(), RandomRotation()).transform.parent = transform;
    }

    private Vector3 RandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(outerBound.min.x, outerBound.max.x), 
                                       Random.Range(outerBound.min.y, outerBound.max.y), -1);

        while (innerBound.Contains(position))
        {
            position = new Vector3(Random.Range(outerBound.min.x, outerBound.max.x),
                                       Random.Range(outerBound.min.y, outerBound.max.y), -1);
        }

        return position;
    }

    private Quaternion RandomRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360f));
    }
}

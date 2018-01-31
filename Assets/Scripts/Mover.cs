using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    protected float speedMean = 1f;
    protected float speedVariance = 0.05f;

    protected float speed = 1f;
    protected float turningSpeed = 500f;
    public Waypoint currentWaypoint;
    private Vector3 currentWaypointTargetPosition;

    protected bool canMove { get; private set; }

    protected bool randomTargetDisplacement;
    protected bool randomizeSpeed;

    private Animator animator;
    
	void Start ()
    {
        canMove = true;
        randomTargetDisplacement = true;
        animator = GetComponentInChildren<Animator>();
        randomizeSpeed = false;
    }

    void Update()
    {
        Move();
    }

    protected void Move ()
    {
        Vector3 dir = (currentWaypointTargetPosition - transform.position).normalized;
        float angle = Vector2.SignedAngle(transform.right, dir);
        if (angle > 0)
        {
            transform.Rotate(0, 0, Mathf.Min(turningSpeed * Time.deltaTime, angle));
        }
        else
        {
            transform.Rotate(0, 0, Mathf.Max(-turningSpeed * Time.deltaTime, angle));
        }

        if (!canMove)
        {
            if (animator != null)
                animator.SetBool("isMoving", false);
            return;
        }
        if (animator != null)
            animator.SetBool("isMoving", true);

        if ((transform.position - currentWaypointTargetPosition).sqrMagnitude < 0.1f * 0.1f)
        {
            UpdateWaypoint();
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    private void UpdateWaypoint()
    {
        currentWaypoint.WaypointReached(this);

        currentWaypoint = currentWaypoint.neighbours[Random.Range(0, currentWaypoint.neighbours.Length)];
        currentWaypointTargetPosition = currentWaypoint.transform.position +
                                        (randomTargetDisplacement ? OnUnitCircle() : Vector3.zero) * 0.25f;
        if (randomizeSpeed)
        {
            speed = GaussianDistribution.Generate(speedMean, speedVariance);
        }
    }

    private Vector3 OnUnitCircle()
    {
        float randomAngle = Random.Range(0, 360.0f);
        return new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0);
    }

    public void SetWaypoint(Waypoint waypoint)
    {
        currentWaypoint = waypoint;
        if((transform.position - waypoint.transform.position).sqrMagnitude < Mathf.Epsilon)
        {
            UpdateWaypoint();
        }
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}

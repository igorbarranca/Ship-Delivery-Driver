using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float patrolSpeed = 5f;
    [SerializeField] float distanceRange = .2f;

    [SerializeField] float rotationSpeed = 1f;

    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        //FaceDirection();
    }

    void Patrol()
    {
        Vector2 nextPointPos = waypoints[waypointIndex].position;
        float step = patrolSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, nextPointPos, step);

        //transform.LookAt(nextPointPos);
        transform.right = nextPointPos - (Vector2)transform.position;

        if(Vector2.Distance(transform.position, nextPointPos) < distanceRange)
        {
            waypointIndex++;
            if(waypointIndex > waypoints.Length - 1)
            {
                waypointIndex = 0;
            }
        }
    }

    void FaceDirection()
    {
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, waypoints[waypointIndex].position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class SimplePatrol : MonoBehaviour
{
    Vector3 targetPosition;
    public Transform startWaypoint;
    public Transform endWaypoint;
    public float movementSpeed;
    private void Start()
    {
        // At start, move to start waypoint and set the target to end waypoint
        transform.position = startWaypoint.position;
        targetPosition = endWaypoint.position;
    }
    void Update()
    {
        // Constantly move towards the target position with the speed movementSpeed
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        // If we are nearly at the end waypoint 
        if(Vector3.Distance (transform.position, endWaypoint.position) < 0.01)
        {
            // Switch targetPosition to start point
            targetPosition = startWaypoint.position;
        }
        // If we are nearly at the start waypoint
        else if(Vector3.Distance(transform.position, startWaypoint.position) < 0.01)
        {
            // Switch targetPosition to end point
            targetPosition = endWaypoint.position;
        }
    }
}

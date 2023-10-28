using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credit: https://www.youtube.com/watch?v=ly9mK0TGJJo
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float speed;

    private int targetWaypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0,1,elapsedPercentage);
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);
         transform.rotation = Quaternion.Lerp(previousWaypoint.rotation, targetWaypoint.rotation, elapsedPercentage);
         
        if(elapsedPercentage >= 1) {
            TargetNextWaypoint();
        }

    }

    private void TargetNextWaypoint() {
        previousWaypoint = _waypointPath.GetWaypoint(targetWaypointIndex);   
        targetWaypointIndex = _waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = _waypointPath.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("entered platform");
        other.transform.SetParent(transform);

    }

    private void OnTriggerExit(Collider other) {
        other.transform.SetParent(null);
    }
}

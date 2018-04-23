using UnityEngine;
using System.Collections;

public class BotWaypointPatrol : MonoBehaviour
{
    
    public Transform[] waypoint;
    public bool[] waitOrNot;
    [Range(0f, 50f)]
    public float patrolSpeed = 3.0f;
    [Range(0f, 10f)]
    public float waypointDelayTime = 3.0f;
    private float wayPointDistance = 0.0f;
    public float baseWaitTime = 20f;
    public float waypointThreshold = 0.5f;
    public Transform theChosenWaypoint = null;
    private bool notAtBase = false;
    public bool patroling = false;
    public float rotSpeed = 0.2f;

    void Start()
    {

        patroling = false;
        Invoke("DecideState", .01f);

    }

    void Update()
    {
        
        

        if (theChosenWaypoint != null)
        {

            wayPointDistance = (theChosenWaypoint.position - this.transform.position).magnitude;

        }

        if (patroling == true && wayPointDistance > waypointThreshold && theChosenWaypoint != null)
        {
            //this.transform.LookAt(theChosenWaypoint);
            Vector3 direction = theChosenWaypoint.transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            this.transform.Translate(patrolSpeed * Vector3.forward * Time.deltaTime);

        }

        else if (patroling == true && wayPointDistance <= waypointThreshold && theChosenWaypoint != null)
        {

            for (int t = 0; t < waypoint.Length; t++)
            {

                if (theChosenWaypoint == waypoint[t] && waitOrNot[t] == true)
                {

                    patroling = false;
                    if (notAtBase == true)
                    {
                        Invoke("DecideState", waypointDelayTime);
                    }
                    else
                    {
                        Invoke("DecideState", baseWaitTime);
                    }
                }

                else if (theChosenWaypoint == waypoint[t] && waitOrNot[t] == false)
                {

                    patroling = false;
                    Invoke("DecideState", .01f);

                }

            }

        }

    }

    void DecideState()
    {


        patroling = false;

        if(notAtBase == true)
        {
            theChosenWaypoint = waypoint[0];
            notAtBase = false;
        }
        else
        {
            theChosenWaypoint = waypoint[(Random.Range(0, waypoint.Length))];
            notAtBase = true;
        }
        

        
            if (waypoint != null)
        {

            Invoke("PatrolState", .01f);

        }

        else if (waypoint == null)
        {

            Debug.Log("Your waypoint Array is empty.");

        }

    }
    
    void PatrolState()
    {

        patroling = true;

    }
}
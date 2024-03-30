using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWayPoints : MonoBehaviour
{
    public List<GameObject> waypoints; // List of GameObjects representing the waypoints for the object to follow.
    public float speed=0.1f; // define the speed with initial value = 0.1
    int index=0; // define the index with initial value = 0

    // public bool isLoop= true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private  void Update()
    {
        Vector3 destination =waypoints[index].transform.position; // Sets the destination to the position of the waypoint at the specified index.
        Vector3 newpos = Vector3.MoveTowards(transform.position,destination,speed * Time.deltaTime);// Calculates a new position that moves towards the destination.
        transform.position = newpos; // Updates the object's position to the new position calculated.

        float distance =Vector3.Distance(transform.position,destination);// Calculates the distance between the object's current position and the destination.
        if(distance <= 0.05){
            // If the object is close enough to the destination...

            if(index < waypoints.Count-1){
                 // If there are more waypoints to follow, move to the next waypoint.
                index++;
            }
            // else{
            //     if(isLoop){
            //         index =0;
            //     }
            // }
            
        }
    }
}

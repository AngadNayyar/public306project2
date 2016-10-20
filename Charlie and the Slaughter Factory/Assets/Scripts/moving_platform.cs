using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * This class calls Platform_path and transforms the platform along the dedicated path using the provided points
 * 
 * Charlie and the Slaughter Factory : Teven Studios
 * */

public class moving_platform : MonoBehaviour
{

    //instantiates the enum depending on the required movement
    public enum Path_Type
    {
        MoveTowardsPoint, // move towards the next point in the path
        Lerp // incremental increase between two points
    }

    //instantiates
    public Platform_path_def Path;
    public float Speed = 1;

    // private 
    private IEnumerator<Transform> current_point;
    private Path_Type Type = Path_Type.MoveTowardsPoint; // default value for the Path
    private float MaxDistanceToGoal = .1f; // close enough to point, can move

    public void Start()
    {
        if (Path == null) // error handling (no given points for the path)
        {
            Debug.LogError("Path is null, points provided", gameObject);
            return; //exit
        }

        current_point = Path.GetPathEnumerator(); // gets the numerator from the other script
        current_point.MoveNext(); //calls the next iteration through the yield

        if (current_point.Current == null) // break out of start, no points in the path
        {
            return;
        }

        transform.position = current_point.Current.position;// set as first point in path
    }

    public void Update()
    {
        if (current_point == null)
        {
            return; // if there isn't a path moving towards
        }

        if (Type == Path_Type.MoveTowardsPoint)
        { // move towards target point
            //transform.position = Vector3.MoveTowards(transform.position, current_point.Current.position, Time.deltaTime * Speed); //Time.deltaTime makes it smooth
        }
        else if (Type == Path_Type.Lerp)
        { // linear, same input
            transform.position = Vector3.Lerp(transform.position, current_point.Current.position, Time.deltaTime * Speed);
        }

        //see if close enough that hitting point, that can move towards the next point
        //float distanceSquared = (transform.position - current_point.Current.position).sqrMagnitude;
        //if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
        //{
        //    current_point.MoveNext();
        //}
    }
}
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

/**
 * This class uses the points provided to draw the path in view finder, and make the path and enumerator for moving_platform script to use and move along
 * 
 * Charlie and the Slaughter Factory : Teven Studios
 * */
public class Platform_path_def : MonoBehaviour
{

    public Transform[] Path_points; // the points the path is created along

    public IEnumerator<Transform> GetPathEnumerator()
    {
        if (Path_points == null || Path_points.Length < 1) // only need one point to follow a path (valid condition)
        {
            yield break; // terminate the sequence immediately
        }

        int direction = 1; // start moving forward by default
        int index = 0; // start index at 0

        while (true) // infinite loop
        {
            yield return Path_points[index]; // wait for call from moving_platform

            if (index <= 0) // execution resumes when moves
            {
                direction = 1; // positive (move forward)
            }
            else if (index >= Path_points.Length - 1)
            {
                direction = -1; // move backwards
            }

            index = index + direction;
        }
    }

    // draw on scene so can easily move
    // this is used mostly for easy creation in Unity
    public void OnDrawGizmos()
    {
        if (Path_points == null || Path_points.Length < 2)
        {
            return;
        }
        for (int i = 1; i < Path_points.Length; i++)
        { // draws the line between adjacent points
            Gizmos.DrawLine(Path_points[i - 1].position, Path_points[i].position);
        }
    }
}

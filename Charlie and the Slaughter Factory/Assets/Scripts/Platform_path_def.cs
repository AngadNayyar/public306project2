using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

/**
 * This class uses the points provided to draw the path in view finder, and make the path and enumerator for moving_platform script to use and move along
 * */
public class Platform_path_def : MonoBehaviour
{

    public Transform[] Points; // the points the path is created along

    public IEnumerator<Transform> GetPathEnumerator()
    {
        if (Points == null || Points.Length < 1) // only need one point to follow a path (valid condition)
        {
            yield break; // terminate the sequence immediately
        }

        int direction = 1; // start moving forward by default
        int index = 0;

        while (true) // infinite loop
        {
            yield return Points[index]; // wait for call from moving_platform

            if (index <= 0) // execution resumes when moves
            {
                direction = 1; // positive (move forward)
            }
            else if (index >= Points.Length - 1)
            {
                direction = -1; // move backwards
            }
            index = index + direction;
        }
    }

    //draw on scene so can easily move
    public void OnDrawGizmos()
    {
        if (Points == null || Points.Length < 2)
        {
            return;
        }
        for (int i = 1; i < Points.Length; i++)
        {
            Gizmos.DrawLine(Points[i - 1].position, Points[i].position);
        }
    }
}

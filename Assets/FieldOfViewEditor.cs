using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = target as FieldOfView;

        Vector3 angleA = fov.DirectionFromAngle(-fov.Angle / 2, false);
        Vector3 angleB = fov.DirectionFromAngle(fov.Angle / 2, false);

        Handles.color = Color.white;
        Handles.DrawLine(fov.transform.position, fov.transform.position + angleA * fov.Distance);
        Handles.DrawLine(fov.transform.position, fov.transform.position + angleB * fov.Distance);
    }
}

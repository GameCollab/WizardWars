using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    /* Find all objects of type in some cast shape */
    public static List<GameObject> GetAllTypeInLine(float thickness, float length, Vector3 direction, Vector3 castPoint, string tag)
    {
        List<GameObject> targets = new List<GameObject>();
        //Instantiate the LineCast Prefab.
        //Adjust the size for thickness.
        //Position the origin position onto the cast point
        //Have the opposing side go in the direction
        //Get all objects that collide with it
        //Get a smaller list of only those with the tag
        return targets;
    }

    public static List<GameObject> GetAllTypeInCone(float angle, float length, Vector3 direction, Vector3 castPoint, string tag)
    {
        
    }

    public static List<GameObject> GetAllTypeInMultiLine(int number, float angle, float length, Vector3 direction, Vector3 castPoint, string tag)
    {

    }

    public static List<GameObject> GetAllTypeInCircle(float radius, Vector3 castPoint, string tag)
    {

    }

    public static List<GameObject> GetAllTypeInRectangle(float x, float y, Vector3 castPoint, string tag)
    {

    }
}

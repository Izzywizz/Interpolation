using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenosFollower : MonoBehaviour
{
    public GameObject poi; // Point of Interest
    public float u = 0.1f;
    public Vector3 p0, p1, p01;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Get the postion of this and the poi
        p0 = this.transform.position;
        p1 = poi.transform.position;

        // Interpolate between the two, using standard formula
        p01 = (1 - u) * p0 + u * p1;

        // move this to the new position
        this.transform.position = p01;
    }
}

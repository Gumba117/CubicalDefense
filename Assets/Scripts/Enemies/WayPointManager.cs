using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public Transform[] wayPoints;

    public Transform[] GetWaypoints()
    {
        return wayPoints;
    }
}

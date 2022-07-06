using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RouteManager : MonoBehaviour
{

    public abstract List<Vector2> GroundWaypoints { get; }

    public abstract List<Vector2> AirWaypoints { get; }


}

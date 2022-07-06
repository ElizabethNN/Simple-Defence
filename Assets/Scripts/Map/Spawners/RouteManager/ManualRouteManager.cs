using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRouteManager : RouteManager
{

    //TODO: serialize dictionary in inspector
    //TODO: add line to list converter

    [SerializeField]
    private List<Vector2> groundWaypoints;

    [SerializeField]
    private List<Vector2> airWaypoints;


    public override List<Vector2> GroundWaypoints {
        get {
            return groundWaypoints;
        }
    }

    public override List<Vector2> AirWaypoints {
        get {
            return airWaypoints;
        }
    }

}

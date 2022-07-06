using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : Enemy
{

    protected override void AfterRouteMangerChanged()
    {
        route = RouteManager.AirWaypoints;
        direction.x = route[0].x.CompareTo(transform.position.x);
        direction.y = route[0].y.CompareTo(transform.position.y);
        direction = direction.normalized;
    }
}

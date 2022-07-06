using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{

    //�������� ��� ��������, �� �� �� ���� �������
    //������ ����, ����� ��������� � ������� ������������ ����� ����� ��� ���� ��������, ���� ������ ��������� �������������
    protected override void AfterRouteMangerChanged()
    {
        route = RouteManager.GroundWaypoints;
        direction.x = route[0].x.CompareTo(transform.position.x);
        direction.y = route[0].y.CompareTo(transform.position.y);
        direction = direction.normalized;
    }
}

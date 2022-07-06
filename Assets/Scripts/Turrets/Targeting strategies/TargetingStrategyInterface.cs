using System.Collections.Generic;
using UnityEngine;

public interface TargetingStrategyInterface
{
    GameObject chooseTarget(List<GameObject> targets, Turret self);

}

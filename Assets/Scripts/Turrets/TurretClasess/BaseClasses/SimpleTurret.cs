using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleTurret : Turret
{
    protected override List<GameObject> GetTargets()
    {
        return enemyManager.Enemies;
    }

}

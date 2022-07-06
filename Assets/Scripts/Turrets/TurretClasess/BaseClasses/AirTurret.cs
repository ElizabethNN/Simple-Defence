using System.Collections.Generic;
using UnityEngine;

public abstract class AirTurret : Turret
{
    protected override List<GameObject> GetTargets()
    {
        return enemyManager.AirEnemies;
    }

}

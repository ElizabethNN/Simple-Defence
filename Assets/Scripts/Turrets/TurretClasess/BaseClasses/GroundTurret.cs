using System.Collections.Generic;
using UnityEngine;

public abstract class GroundTurret :Turret
{

    protected override List<GameObject> GetTargets()
    {
        return enemyManager.GroundEnemies;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTurret : SimpleTurret
{
    protected override void Action()
    {
        GameObject bullet = Instantiate(LevelManager.CurrentTurretLevel.Bullet, transform.position, new Quaternion());
        bullet.GetComponent<TargetBullet>().InitBullet(LevelManager.CurrentTurretLevel.Damage, target, LevelManager.CurrentTurretLevel.Special);
    }
}

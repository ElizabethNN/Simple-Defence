using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTurret : GroundTurret
{
    protected override void Action()
    {
        GameObject bullet = Instantiate(LevelManager.CurrentTurretLevel.Bullet, transform.position, new Quaternion());
        bullet.GetComponent<PointBullet>().InitBullet(target.transform.position, LevelManager.CurrentTurretLevel.Damage, LevelManager.CurrentTurretLevel.Special);
    }
}

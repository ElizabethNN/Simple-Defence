using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : SimpleTurret
{
    protected override void Action()
    {
        int i = 0;
        while (i < Mathf.Ceil(LevelManager.CurrentTurretLevel.Special)) {
            GameObject bullet = Instantiate(LevelManager.CurrentTurretLevel.Bullet, transform.position, new Quaternion());
            bullet.GetComponent<TargetBullet>().InitBullet(LevelManager.CurrentTurretLevel.Damage, target, 0f);
            i++;
        }
    }

}

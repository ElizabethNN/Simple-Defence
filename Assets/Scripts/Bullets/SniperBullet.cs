using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : TargetBullet
{

    protected override void Action(GameObject target, float Special)
    {
        float r = Random.Range(0, 100);
        if (r < Special) {
            var enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(enemy.Health);
        }
    }

}

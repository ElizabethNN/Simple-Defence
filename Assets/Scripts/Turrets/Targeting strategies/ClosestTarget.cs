using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestTarget : TargetingStrategyInterface
{
    public GameObject chooseTarget(List<GameObject> targets, Turret self)
    {
        float distance = float.MaxValue;
        GameObject result = null;
        foreach (GameObject target in targets) {
            float dist = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - self.transform.position.x, 2) 
                + Mathf.Pow(target.transform.position.y - self.transform.position.y, 2));
            if (dist < distance && dist < self.LevelManager.CurrentTurretLevel.Range) {
                distance = dist;
                result = target;
            }
        }
        return result;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBullet : PointBullet
{
    protected override void Action(Vector3 point, int damage, float special)
    {
        Collider2D[] affected = Physics2D.OverlapCircleAll(point, special, 1 << 6);
        foreach (Collider2D obj in affected) {
            try
            {
                obj.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            catch {
                Debug.Log("Stop killing them, they are already dead");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Special);
    }
}

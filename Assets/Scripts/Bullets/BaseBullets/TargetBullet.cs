using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{
    protected int Damage;
    protected GameObject Target;
    protected float Special;
    [SerializeField]
    protected float Speed;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void Action(GameObject target, float Special) { }

    public void InitBullet(int damage, GameObject gameObject, float special) {
        Target = gameObject;
        Damage = damage;
        Special = special;
        Target.GetComponent<Enemy>().OnEnemyDeath += SelfDestroy;
        Target.GetComponent<Enemy>().OnEnemyFinishes += SelfDestroy;
    }

    private void SelfDestroy(GameObject enemy)
    {
        if(gameObject != null)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = (Target.transform.position - transform.position).normalized * Speed;

        Vector3 targetVect = Target.transform.position - transform.position;

        var angle = Vector2.SignedAngle(targetVect, transform.up);

        transform.Rotate(Vector3.back, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Target) {
            Target.GetComponent<Enemy>().TakeDamage(Damage);
            if(Target != null)
                Action(Target, Special);
            if(gameObject != null)
                Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Target.GetComponent<Enemy>().OnEnemyDeath -= SelfDestroy;
        Target.GetComponent<Enemy>().OnEnemyFinishes -= SelfDestroy;
    }
}

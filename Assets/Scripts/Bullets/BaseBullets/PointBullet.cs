using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointBullet : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    [SerializeField]
    protected float Speed;
    protected Vector3 Point;
    protected float Special;
    protected int Damage;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected abstract void Action(Vector3 point, int damage, float special);

    public void InitBullet(Vector3 point, int damage, float special) {
        Point = point;
        Damage = damage;
        Special = special;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - Point.x) > 0.01 || Mathf.Abs(transform.position.y - Point.y) > 0.01)
        {
            rigidbody2D.velocity = (Point - transform.position).normalized * Speed;
        }
        else {
            Action(transform.position, Damage, Special);
            Destroy(gameObject);
        }

        Vector3 targetVect = Point - transform.position;

        var angle = Vector2.SignedAngle(targetVect, transform.up);

        transform.Rotate(Vector3.back, angle);
    }
}

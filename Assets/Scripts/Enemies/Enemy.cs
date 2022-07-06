using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public delegate void OnEnemyHandler(GameObject enemy);
    public event OnEnemyHandler OnEnemyDeath;
    public event OnEnemyHandler OnEnemyFinishes;

    

    protected RouteManager routeManager;
    public RouteManager RouteManager {
        protected get {
            return routeManager;
        }
        set {
            routeManager = value;
            AfterRouteMangerChanged();
        }
    }

    protected List<Vector2> route;
    protected int waypoint = 0;
    protected Vector3 direction;

    Rigidbody2D rb;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int bounty;

    public int Bounty {
        get {
            return bounty;
        }
    }

    public int Health {
        get {
            return health;
        }
    }

    public float Speed {
        get {
            return speed;
        }
    }

    public int Damage {
        get {
            return damage;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - route[waypoint].x) > 0.01 || Mathf.Abs(transform.position.y - route[waypoint].y) > 0.01) {
            rb.velocity = direction * speed;
        }
        else
        {
            waypoint = (waypoint + 1 == route.Count) ? waypoint : waypoint + 1;
        }
        direction.x = route[waypoint].x - transform.position.x;
        direction.y = route[waypoint].y - transform.position.y;
        direction = direction.normalized;
        Action();
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            OnEnemyDeath?.Invoke(gameObject);
            SendMessage("Death");
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }
    protected abstract void AfterRouteMangerChanged();

    protected virtual void Action() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base")
        {
            OnEnemyFinishes?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}

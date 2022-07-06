using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{

    public TurretLevelManager LevelManager {
        get; private set;
    }
    public TargetingStrategyInterface Targeting;
    protected EnemyManager enemyManager;
    protected GameObject target = null;
    protected Enemy enemy = null;
    float timer = 0;

    void Start()
    {
        LevelManager = GetComponent<TurretLevelManager>();
        enemyManager = EnemyManager.GetInstance();
        Targeting = new ClosestTarget();
    }


    //TODO: change to wrapper
    protected abstract List<GameObject> GetTargets();

    protected abstract void Action();

    private void FixedUpdate()
    {
        var tr = Targeting.chooseTarget(GetTargets(), this);
        if (tr != target)
            ResetTarget(target);
        target = tr;
        
        if (target != null)
        {
            enemy = target.GetComponent<Enemy>();
            enemy.OnEnemyDeath += ResetTarget;
            enemy.OnEnemyFinishes += ResetTarget;
     
            timer -= Time.fixedDeltaTime;
            if (timer <= 0 && target != null)
            {
                Action();
                timer = LevelManager.CurrentTurretLevel.AttackSpeed;
            }

            float dist = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2)
                    + Mathf.Pow(target.transform.position.y - transform.position.y, 2));
            if (dist > LevelManager.CurrentTurretLevel.Range)
                ResetTarget(target);

            Vector3 targetVect = target.transform.position - transform.position;

            var angle = Vector2.SignedAngle(targetVect, transform.up);

            transform.Rotate(Vector3.back, angle);
        }
    }

    private void ResetTarget(GameObject enemy) {
        target = null;
        enemy = null;
    }
}

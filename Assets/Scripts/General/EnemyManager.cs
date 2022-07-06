using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> groundEnemies = new List<GameObject>();
    [SerializeField]
    private List<GameObject> airEnemies = new List<GameObject>();
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    private Spawner[] spawners;

    public List<GameObject> Enemies {
        get {
            return enemies;
        }
    }

    public List<GameObject> GroundEnemies {
        get {
            return groundEnemies;
        }
    }
    public List<GameObject> AirEnemies {
        get {
            return airEnemies;
        }
    }

    private void Awake()
    {
        if (_instance != null)
            enabled = false;
        _instance = this;
    }

    private void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
            spawner.OnEnemySpawn += OnEnemySpawn;
    }

    private static EnemyManager _instance;

    private EnemyManager() { }

    public static EnemyManager GetInstance() {
        return _instance;
    }

    void OnEnemySpawn(GameObject enemy) {

        enemies.Add(enemy);
        if (enemy.TryGetComponent<GroundEnemy>(out GroundEnemy _))
            groundEnemies.Add(enemy);
        else
            airEnemies.Add(enemy);
        Enemy curr_enemy = enemy.GetComponent<Enemy>();
        curr_enemy.OnEnemyDeath += onEnemyDespawn;
        curr_enemy.OnEnemyFinishes += onEnemyDespawn;
    }

    void onEnemyDespawn(GameObject enemy) {
        if (enemy.TryGetComponent<GroundEnemy>(out GroundEnemy _))
            groundEnemies.Remove(enemy);
        else
            airEnemies.Remove(enemy);
        enemies.Remove(enemy);
    }

    private void OnDestroy()
    {
        _instance = null;
        foreach (Spawner spawner in spawners)
            spawner.OnEnemySpawn -= OnEnemySpawn;
    }

}

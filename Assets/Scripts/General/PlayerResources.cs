using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerResources : MonoBehaviour
{
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent<int> OnMoneyChanged;

    [SerializeField]
    private int StartHealth;
    [SerializeField]
    private int StartMoney;

    private static PlayerResources _instance;
    private Spawner[] spawners;

    private int health;
    private int money;

    public int Money {
        get {
            return money;
        }
        set {
            money = value;
            OnMoneyChanged?.Invoke(value);
        }
    }

    public int Health {
        get {
            return health;
        }
        set {
            health = value;
            if (value <= 0)
                GameOver();
            OnHealthChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        money = StartMoney;
        health = StartHealth;

        if (_instance != null)
            enabled = false;
        _instance = this;

        spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
            spawner.OnEnemySpawn += OnEnemySpawn;
    }

    public static PlayerResources GetInstance() {
        return _instance;
    }

    private void OnEnemySpawn(GameObject enemy) {
        Enemy en = enemy.GetComponent<Enemy>();
        en.OnEnemyDeath += (GameObject enemy1) =>
        {
            Money += en.Bounty;
        };
        en.OnEnemyFinishes += (GameObject enemy1) =>
        {
            Health -= en.Damage;
        };
    }

    private void OnDestroy()
    {
        _instance = null;
        foreach (Spawner spawner in spawners)
            spawner.OnEnemySpawn -= OnEnemySpawn;
    }

    private void GameOver() {
        SceneManager.LoadScene(0);
    }
}


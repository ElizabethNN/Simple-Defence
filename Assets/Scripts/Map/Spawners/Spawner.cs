using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public delegate void OnSpawnEnemyHandler(GameObject enemy);
    public event OnSpawnEnemyHandler OnEnemySpawn;

    [System.Serializable]
    public struct Wave {
        public GameObject Enemy;
        public int Count;
    }

    [SerializeField]
    private float CurrentDelay;
    [SerializeField]
    private float SpawnDelay;
    [SerializeField]
    private List<Wave> waves;
    [SerializeField]
    private int count;
    [SerializeField]
    private int wave;
    [SerializeField]
    private int WaveDelay;


    RouteManager manager;

    private void Start()
    {
        manager = GetComponent<RouteManager>();
    }

    void FixedUpdate() {
        if (CurrentDelay < 0 ) {
            Vector3 tr = transform.position;
            tr.z = -1;
            GameObject o = Instantiate(waves[wave].Enemy, tr, new Quaternion());
            if (count + 1 == waves[wave].Count)
            {
                count = 0;
                wave = wave + 1 == waves.Count ? 0 : wave + 1;
                CurrentDelay = WaveDelay;
            }
            else {
                count++;
                CurrentDelay = SpawnDelay;
            }
            o.GetComponent<Enemy>().RouteManager = manager;
            OnEnemySpawn?.Invoke(o);
        }
        CurrentDelay -= Time.fixedDeltaTime;
    }
    
}

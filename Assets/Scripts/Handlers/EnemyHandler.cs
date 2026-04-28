using System;
using System.Buffers;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyHandler : MonoBehaviour
{
    public ObjectPool<GameObject> enemyPool;
    //current enemies in the scene
    public List<GameObject> currentEnemies;

    public GameObject EnemyPrefab;

    public GameObject player;
    [SerializeField] private ThemeMusic themeMusic;
    [SerializeField] private elonHealth elonHealth;
    [SerializeField] private markHealth markHealth;

    public void Awake()
    {
        enemyPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(EnemyPrefab),
            actionOnGet: (obj) => obj.SetActive(true),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 20,
            maxSize: 100
        );
    }
    // 2 minute spawn with 5 second intervals, can be adjusted for testing 

    bool markSpawned = false;
    bool elonSpawned = false;
    public void FixedUpdate()
    {

        if (currentEnemies.Count < 50)
        {
            if (Time.time > 300f)
            {
                Debug.Log("spawn elon");
                if (!elonSpawned)
                {
                    elonSpawned = true;
                    elonHealth.spawnElon();
                }

            }
            else if (Time.time > 120f)
            {
                Debug.Log("spawn mark");
                if (!markSpawned)
                {
                    markSpawned = true;
                    markHealth.spawnMark();
                }
                CircleSpawnEnemies(50f, 1f, Time.fixedDeltaTime);
            }
            else if (Time.time > 60f)
            {
                Debug.Log("spawn more advanced");
                CircleSpawnEnemies(30f, 1f, Time.fixedDeltaTime);
            }
            else
            {
                Debug.Log("spawn basic");
                CircleSpawnEnemies(20f, 2f, Time.fixedDeltaTime);
            }
        }
        UpdateEnemies();

        float energy = Mathf.Clamp01(currentEnemies.Count / 16f);
        themeMusic.SetEnergy(energy);
    }
    float deltaTimeCounter = 0f;
    public void CircleSpawnEnemies(float radius, float spawnInterval, float deltaTime)
    {
        //spawn enemies in a circle around the player at a set interval
        deltaTimeCounter += deltaTime;
        if (deltaTimeCounter >= spawnInterval)
        {
            deltaTimeCounter = 0f;
            float angle = UnityEngine.Random.Range(0f, 360f);
            Vector3 spawnPosition = player.transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
            SpawnEnemy(EnemyTypes.Walker, spawnPosition);
        }
    }
    public void SpawnEnemy(EnemyTypes type, Vector3 position)
    {
        GameObject enemy = enemyPool.Get();
        enemy.transform.position = position;
        switch (type)
        {
            case EnemyTypes.Walker:
                var stats = Walker.InitializeStats(Time.time);
                var enemyComponent = new EnemyStats();
                enemyComponent.enemyType = type;
                enemyComponent.maxHealth = stats.maxHealth;
                enemyComponent.speed = stats.speed;
                enemyComponent.currentHealth = stats.currentHealth;
                enemyComponent.damage = stats.damage;
                enemyComponent.range = stats.range;
                enemyComponent.xpamount = stats.xpamount;
                enemyComponent.stats = stats.stats;
                enemyComponent.enemyType = stats.enemyType;
                enemystruct enemyStruct = enemy.GetComponent<enemystruct>();
                enemyStruct.InitializeEnemy(enemyComponent);
                break;
            default:
                Debug.LogError($"Unsupported enemy type: {type}");
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        currentEnemies.Add(enemy);
    }
    public void DespawnEnemy(GameObject enemy)
    {
        var enemyComponent = enemy.GetComponent<enemystruct>();
        enemyComponent.enemyStats.currentHealth = enemyComponent.enemyStats.maxHealth;
        currentEnemies.Remove(enemy);
        enemyPool.Release(enemy);
    }

    public void UpdateEnemies()
    {
        foreach (var enemy in currentEnemies)
        {
            var enemyComponent = enemy.GetComponent<enemystruct>();
            var enemyStats = enemyComponent.enemyStats;
            if (enemyStats == null)
            {
                Debug.LogError("EnemyStats component missing on enemy object");
                continue;
            }
            switch (enemyStats.enemyType)
            {
                case EnemyTypes.Walker:
                    // Execute walker behavior
                    Walker.EnemyBehavior(enemy, enemyStats, player);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
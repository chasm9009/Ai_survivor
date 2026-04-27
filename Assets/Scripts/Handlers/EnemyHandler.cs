using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyHandler : MonoBehaviour
{
    public Delegate[] enemyBehaviors;
    public ObjectPool<GameObject> enemyPool;
    //current enemies in the scene
    public List<GameObject> currentEnemies;

    public void Update()
    {

    }
    public void SpawnEnemy(EnemyTypes type, Vector3 position)
    {
        GameObject enemy = enemyPool.Get();
        enemy.transform.position = position;
        var enemyComponent = enemy.GetComponent<Enemy>();
        enemyComponent.enemyType = type;
        currentEnemies.Add(enemy);
    }
    public void DespawnEnemy(GameObject enemy)
    {
        enemyPool.Release(enemy);
        currentEnemies.Remove(enemy);
    }

    public void UpdateEnemies()
    {
        foreach (var enemy in currentEnemies)
        {
            switch (enemy.GetComponent<Enemy>().enemyType)
            {
                case EnemyTypes.grunt:
                    // Execute grunt behavior
                    enemyBehaviors[0]?.DynamicInvoke();
                    break;
                case EnemyTypes.runner:
                    // Execute runner behavior
                    enemyBehaviors[1]?.DynamicInvoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
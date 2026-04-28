using UnityEngine;

public static class Walker
{
    public static void UpdateBehavior(GameObject enemyObject, EnemyStats enemyStats, GameObject player)
    {
        // Simple walking behavior: move towards the player at a constant speed
        enemyObject.transform.position = Vector3.MoveTowards(enemyObject.transform.position, player.transform.position, enemyStats.speed * Time.deltaTime);
    }
    public static void EnemyBehavior(GameObject enemyObject, EnemyStats enemyStats, GameObject player)
    {
        Debug.Log("Walker behavior executing");
        Debug.Log($"Speed: {enemyStats.speed}, Delta: {Time.deltaTime}");
        enemyObject.transform.position = Vector3.MoveTowards(enemyObject.transform.position, player.transform.position, enemyStats.speed * Time.deltaTime);
    }
    public static EnemyStats InitializeStats(float timePassed)
    {
        EnemyStats stats = new EnemyStats();
        stats.enemyType = EnemyTypes.Walker;
        stats.maxHealth = 20 * (int)(0.01 * Time.time);
        stats.currentHealth = 20 * (int)(0.01 * Time.time);
        stats.speed = 1f * (int)(0.01 * Time.time);
        stats.xpamount = 10f * (int)(0.01 * Time.time);
        stats.damage = 10 * (int)(0.01 * Time.time);
        Debug.Log($"Initialized Walker stats: Health={stats.currentHealth}, Speed={stats.speed}");
        return stats;
    }
}
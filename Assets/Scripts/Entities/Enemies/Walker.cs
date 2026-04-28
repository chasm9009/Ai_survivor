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
        stats.maxHealth = 30;
        stats.currentHealth = 30;
        stats.speed = 1.3f;
        stats.xpamount = 50f;
        stats.damage = 10;
        Debug.Log($"Initialized Walker stats: Health={stats.currentHealth}, Speed={stats.speed}");
        return stats;
    }
}
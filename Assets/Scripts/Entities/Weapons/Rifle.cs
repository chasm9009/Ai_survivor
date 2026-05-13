using UnityEngine;

public static class Rifle
{
    public static float lastFireTime = 0f;

    public static bool Fire(Stats playerStats, float deltaTime)
    {
        if (Time.time - lastFireTime >= playerStats.fireRate * 0.5f) // Faster firing
        {
            lastFireTime = Time.time;
            return true;
        }
        return false;
    }
    public static void RifleBehavior(Stats playerStats, BulletHandler bulletHandler, float deltaTime, Vector2 PlayerDirection, Vector3 position)
    {
        // smaller spread for a faster, more accurate rifle
        Vector2 rifleInaccuracy = Random.insideUnitCircle * 0.05f;
        Vector2 rifleDirection = (PlayerDirection + rifleInaccuracy).normalized;
        if (Fire(playerStats, deltaTime))
        {
            bulletHandler.SpawnBullet(BulletTypes.Rifle, position, playerStats, rifleDirection);
        }
    }
}





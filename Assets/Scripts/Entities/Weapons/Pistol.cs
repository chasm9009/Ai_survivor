using UnityEngine;

public static class Pistol
{
    public static float lastFireTime = 0f;

    public static bool Fire(Stats playerStats, float deltaTime)
    {
        if (Time.time - lastFireTime >= playerStats.fireRate)
        {
            lastFireTime = Time.time;
            return true;
        }
        return false;
    }

    public static void PistolBehavior(Stats playerStats, BulletHandler bulletHandler, float deltaTime, Vector2 PlayerDirection, Vector3 position)
    {
        // Implement any specific behavior for the pistol here (e.g., recoil, sound effects, etc.)
        //add a small cone of inaccuracy to the player's direction for the pistol
        Vector2 pistolInaccuracy = Random.insideUnitCircle * 0.1f;
        Vector2 pistolDirection = (PlayerDirection + pistolInaccuracy).normalized;
        // Execute pistol behavior

        if (Fire(playerStats, deltaTime))
        {
            bulletHandler.SpawnBullet(BulletTypes.Pistol, position, playerStats, pistolDirection);
        }
    }
}
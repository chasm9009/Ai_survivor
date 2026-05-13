using UnityEngine;

public static class Knife
{
    public static float lastFireTime = 0f;

    public static bool Fire(Stats playerStats, float deltaTime)
    {
        if (Time.time - lastFireTime >= playerStats.fireRate * 0.8f)
        {
            lastFireTime = Time.time;
            return true;
        }
        return false;
    }

    public static void KnifeBehavior(Stats playerStats, BulletHandler bulletHandler, float deltaTime, Vector2 PlayerDirection, Vector3 position)
    {
        // Implement any specific behavior for the knife here (e.g., recoil, sound effects, etc.)
        //add a small cone of inaccuracy to the player's direction for the knife

        Vector2 knifeDirection = PlayerDirection.normalized;
        // Execute knife behavior

        if (Fire(playerStats, deltaTime))
        {
            bulletHandler.SpawnBullet(BulletTypes.Knife, position, playerStats, knifeDirection);
        }
    }
}
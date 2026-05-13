using UnityEngine;

public static class Shotgun
{
    public static float lastFireTime = 0f;

    public static bool Fire(Stats playerStats, float deltaTime)
    {
        if (Time.time - lastFireTime >= playerStats.fireRate * 2f) // Slower but spread fire
        {
            lastFireTime = Time.time;
            return true;
        }
        return false;
    }
    public static void ShotgunBehavior(Stats playerStats, BulletHandler bulletHandler, float deltaTime, Vector2 PlayerDirection, Vector3 position)
    {
        if (Fire(playerStats, deltaTime))
        {
            int pelletCount = 5;
            float spreadAngle = 20f;
            for (int i = 0; i < pelletCount; i++)
            {
                float angle = Mathf.Lerp(-spreadAngle, spreadAngle, i / (float)(pelletCount - 1));
                Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * PlayerDirection;
                bulletHandler.SpawnBullet(BulletTypes.Shotgun, position, playerStats, spreadDirection.normalized);
            }
        }
    }
}

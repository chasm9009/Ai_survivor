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
}

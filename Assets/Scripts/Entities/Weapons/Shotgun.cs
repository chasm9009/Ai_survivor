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
}

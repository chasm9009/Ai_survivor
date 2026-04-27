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
}
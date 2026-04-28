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
}

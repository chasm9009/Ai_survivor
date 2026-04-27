using UnityEngine;

public static class Pistol
{
    public static float lastFireTime = 0f;
    public static float nextFireRate = 0f;
    public static bool Fire(Stats playerStats, float deltaTime)
    {
        if (nextFireRate == 0f)
    {
        nextFireRate = playerStats.fireRate;
    }

    if (Time.time - lastFireTime >= nextFireRate)
    {
        lastFireTime = Time.time;

        // add jitter AFTER firing
        nextFireRate = playerStats.fireRate + Random.Range(-0.02f, 0.08f);
        nextFireRate = Mathf.Max(0.02f, nextFireRate);

        return true;
    }
    return false;
}

}
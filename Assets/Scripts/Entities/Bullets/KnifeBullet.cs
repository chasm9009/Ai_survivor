using UnityEngine;

public static class KnifeBullet
{
    public static Bullet UpdateKnifeBulletStats(Bullet bulletData, Stats playerStats)
    {
        bulletData.bulletType = BulletTypes.Knife;
        bulletData.damage = playerStats.BaseDamage + 5;
        bulletData.range = 2f; // Short melee-like reach
        bulletData.speed = playerStats.BulletSpeed * 2f; // Fast travel so it hits quickly
        return bulletData;
    }

    public static bool KnifeBehavior(GameObject bulletObject, Bullet bulletData, float deltaTime)
    {
        bulletObject.transform.Translate(bulletData.direction * bulletData.speed * deltaTime, Space.World);
        bulletData.distanceTraveled += bulletData.speed * deltaTime;
        return bulletData.distanceTraveled >= bulletData.range;
    }
}
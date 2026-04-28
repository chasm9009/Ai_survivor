using UnityEngine;

public static class RifleBullet
{
    public static Bullet UpdateRifleBulletStats(Bullet bulletData, Stats playerStats)
    {
        bulletData.bulletType = BulletTypes.Rifle;
        bulletData.damage = playerStats.BaseDamage + 2;
        bulletData.range = playerStats.Range;
        bulletData.speed = playerStats.BulletSpeed * 1.2f;
        return bulletData;
    }

    public static bool RifleBehavior(GameObject bulletObject, Bullet bulletData, float deltaTime)
    {
        bulletObject.transform.Translate(bulletData.direction * bulletData.speed * deltaTime, Space.World);
        bulletData.distanceTraveled += bulletData.speed * deltaTime;
        return bulletData.distanceTraveled >= bulletData.range;
    }
}

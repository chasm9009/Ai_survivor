using UnityEngine;

public static class ShotgunBullet
{
    public static Bullet UpdateShotgunBulletStats(Bullet bulletData, Stats playerStats)
    {
        bulletData.bulletType = BulletTypes.Shotgun;
        bulletData.damage = Mathf.Max(1, playerStats.BaseDamage - 2);
        bulletData.range = playerStats.Range * 0.75f;
        bulletData.speed = playerStats.BulletSpeed * 0.9f;
        return bulletData;
    }

    public static bool ShotgunBehavior(GameObject bulletObject, Bullet bulletData, float deltaTime)
    {
        bulletObject.transform.Translate(bulletData.direction * bulletData.speed * deltaTime, Space.World);
        bulletData.distanceTraveled += bulletData.speed * deltaTime;
        return bulletData.distanceTraveled >= bulletData.range;
    }
}
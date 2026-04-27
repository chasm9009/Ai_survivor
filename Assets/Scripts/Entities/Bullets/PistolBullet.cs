using UnityEngine;

public static class PistolBullet
{
    public static Bullet CreatePistolBullet(Stats playerStats)
    {
        return new Bullet
        {
            bulletType = BulletTypes.Pistol,
            damage = playerStats.BaseDamage,
            range = playerStats.Range,
            speed = playerStats.BulletSpeed,
            sprite = null // Assign a sprite for the pistol bullet if needed
        };
    }
    public static Bullet UpdatePistolBulletStats(Bullet bulletData, Stats playerStats)
    {
        bulletData.damage = playerStats.BaseDamage;
        bulletData.range = playerStats.Range;
        bulletData.speed = playerStats.BulletSpeed;
        return bulletData;
    }

    public static void PistolBehavior(GameObject bulletObject, Bullet bulletData, float deltaTime)
    {
        //linear movement, collision detection, and damage application logic for pistol bullets
        bulletObject.transform.Translate(Vector3.forward * bulletData.speed * deltaTime);
    }
}
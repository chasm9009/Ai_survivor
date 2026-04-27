using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletHandler : MonoBehaviour
{
    public Delegate[] bulletBehaviors;
    public ObjectPool<GameObject> bulletPool;
    //current bullets in the scene
    public List<GameObject> currentBullets;

    public void Update()
    {

    }
    public void SpawnBullet(BulletTypes type, Vector3 position)
    {
        GameObject bullet = bulletPool.Get();
        bullet.transform.position = position;
        var bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.bulletType = type;
        currentBullets.Add(bullet);
    }
    public void DespawnBullet(GameObject bullet)
    {
        bulletPool.Release(bullet);
        currentBullets.Remove(bullet);
    }

    public void UpdateBullets()
    {
        foreach (var bullet in currentBullets)
        {
            switch (bullet.GetComponent<Bullet>().bulletType)
            {
                case BulletTypes.Pistol:
                    // Execute pistol behavior
                    bulletBehaviors[0]?.DynamicInvoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
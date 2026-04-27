using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletHandler : MonoBehaviour
{
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
        //set bullet data based on type
        Bullet bulletComponent;
        switch (type)
        {
            case BulletTypes.Pistol:
                bulletComponent = PistolBullet.CreatePistolBullet(new Stats()); // Pass player stats as needed
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


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
                    PistolBullet.PistolBehavior(bullet, bullet.GetComponent<Bullet>(), Time.deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
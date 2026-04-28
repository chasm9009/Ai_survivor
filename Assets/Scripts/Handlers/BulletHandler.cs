using System;
using System.Buffers;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class BulletHandler : MonoBehaviour
{
    public ObjectPool<GameObject> bulletPool;
    //current bullets in the scene
    public List<GameObject> currentBullets;

    [SerializeField] private Stats playerStats;


    public void Start()
    {
        bulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(pistolBulletPrefab),
            actionOnGet: (obj) => obj.SetActive(true),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 100,
            maxSize: 1000
        );
    }
    [SerializeField] private GameObject pistolBulletPrefab;
    public void SpawnBullet(BulletTypes type, Vector3 position, Stats playerStats, Vector2 direction)
    {
        GameObject bullet = bulletPool.Get();
        bullet.transform.position = position;
        bullet.transform.right = direction;
        var bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.bulletType = type;
        bulletComponent.direction = direction;
        currentBullets.Add(bullet);
        var bulletSound = BulletSound.Instance;
        switch (type)
        {
            case BulletTypes.Pistol:
                bulletSound.PlayBang();
                PistolBullet.UpdatePistolBulletStats(bulletComponent, playerStats);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
    public void DespawnBullet(GameObject bullet)
    {
        bulletPool.Release(bullet);
        currentBullets.Remove(bullet);
        var bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.distanceTraveled = 0f;
        currentBullets.Remove(bullet);
    }

    public void FixedUpdate()
    {
        UpdateBullets();
    }
    public void UpdateBullets()
    {
        List<GameObject> bulletsToRemove = new List<GameObject>();

        foreach (var bullet in currentBullets)
        {
            switch (bullet.GetComponent<Bullet>().bulletType)
            {
                case BulletTypes.Pistol:
                    bool shouldDespawn = PistolBullet.PistolBehavior(bullet, bullet.GetComponent<Bullet>(), Time.deltaTime);
                    if (shouldDespawn) bulletsToRemove.Add(bullet);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var bullet in bulletsToRemove)
        {
            DespawnBullet(bullet);
        }
    }
}
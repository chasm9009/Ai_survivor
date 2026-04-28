using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public BulletHandler bulletHandler;
    public List<Weapon> currentWeapons = new List<Weapon>();

    public void UpdateWeapons(Stats playerStats, BulletHandler bulletHandler, float deltaTime, Vector2 PlayerDirection)
    {
        foreach (var weapon in currentWeapons)
        {
            switch (weapon.weaponType)
            {
                case WeaponTypes.Pistol:
                    //add a small cone of inaccuracy to the player's direction for the pistol
                    Vector2 pistolInaccuracy = UnityEngine.Random.insideUnitCircle * 0.1f;
                    Vector2 pistolDirection = (PlayerDirection + pistolInaccuracy).normalized;
                    // Execute pistol behavior
                    
                    if (Pistol.Fire(playerStats, deltaTime))
                    {
                        bulletHandler.SpawnBullet(BulletTypes.Pistol, transform.position, playerStats, pistolDirection);
                    }
                    break;
                case WeaponTypes.Rifle:
                    // smaller spread for a faster, more accurate rifle
                    Vector2 rifleInaccuracy = UnityEngine.Random.insideUnitCircle * 0.05f;
                    Vector2 rifleDirection = (PlayerDirection + rifleInaccuracy).normalized;
                    if (Rifle.Fire(playerStats, deltaTime))
                    {
                        bulletHandler.SpawnBullet(BulletTypes.Rifle, transform.position, playerStats, rifleDirection);
                    }
                    break;
                case WeaponTypes.Shotgun:
                    if (Shotgun.Fire(playerStats, deltaTime))
                    {
                        int pelletCount = 5;
                        float spreadAngle = 20f;
                        for (int i = 0; i < pelletCount; i++)
                        {
                            float angle = Mathf.Lerp(-spreadAngle, spreadAngle, i / (float)(pelletCount - 1));
                            Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * PlayerDirection;
                            bulletHandler.SpawnBullet(BulletTypes.Shotgun, transform.position, playerStats, spreadDirection.normalized);
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void AddWeapon(WeaponTypes type)
    {
        switch (type)
        {
            case WeaponTypes.Pistol:
                currentWeapons.Add(new Weapon { weaponType = WeaponTypes.Pistol, damage = 10 });
                break;
            case WeaponTypes.Rifle:
                currentWeapons.Add(new Weapon { weaponType = WeaponTypes.Rifle, damage = 15 });
                break;
            case WeaponTypes.Shotgun:
                currentWeapons.Add(new Weapon { weaponType = WeaponTypes.Shotgun, damage = 12 });
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
    public void AddBasedOnLevel(int level)
    {
        switch (level)
        {
            case 3:
            //add shotgun
            case 5:
                AddWeapon(WeaponTypes.Rifle);
                break;
            case 7:
                AddWeapon(WeaponTypes.Shotgun);
                break;
            default:
                break;
        }
    }

}
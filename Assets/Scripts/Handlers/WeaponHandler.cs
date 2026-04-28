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
                    Vector2 inaccuracy = UnityEngine.Random.insideUnitCircle * 0.1f;
                    Vector2 finalDirection = (PlayerDirection + inaccuracy).normalized;
                    // Execute pistol behavior
                    if (Pistol.Fire(playerStats, deltaTime))
                    {
                        bulletHandler.SpawnBullet(BulletTypes.Pistol, transform.position, playerStats, finalDirection);
                        Pistol.lastFireTime = Time.time;
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
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
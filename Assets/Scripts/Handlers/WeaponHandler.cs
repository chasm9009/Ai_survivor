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
                case WeaponTypes.Knife:
                    Knife.KnifeBehavior(playerStats, bulletHandler, deltaTime, PlayerDirection, transform.position);
                    break;
                case WeaponTypes.Pistol:
                    Pistol.PistolBehavior(playerStats, bulletHandler, deltaTime, PlayerDirection, transform.position);
                    break;
                case WeaponTypes.Rifle:
                    Rifle.RifleBehavior(playerStats, bulletHandler, deltaTime, PlayerDirection, transform.position);
                    break;
                case WeaponTypes.Shotgun:
                    Shotgun.ShotgunBehavior(playerStats, bulletHandler, deltaTime, PlayerDirection, transform.position);
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
            case WeaponTypes.Knife:
                currentWeapons.Add(new Weapon { weaponType = WeaponTypes.Knife, damage = 20 });
                break;
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
                //add knife
                AddWeapon(WeaponTypes.Knife);
                break;
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

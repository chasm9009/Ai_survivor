using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public BulletHandler bulletHandler;
    public Delegate[] weaponBehaviors;
    public List<Weapon> currentWeapons;
    private void UpdateWeapons(Stats playerStats)
    {
        foreach (var weapon in currentWeapons)
        {
            switch (weapon.weaponType)
            {
                case WeaponTypes.Pistol:
                    // Execute pistol behavior
                    weaponBehaviors[0]?.DynamicInvoke(playerStats, bulletHandler);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
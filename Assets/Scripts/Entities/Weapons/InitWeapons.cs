using System;

public static class InitWeapons
{
    public static Delegate[] InitializeWeaponBehaviors()
    {
        var result = new Delegate[BulletTypes.GetValues(typeof(BulletTypes)).Length];
        for (int i = 0; i < result.Length; i++)
        {
            switch ((WeaponTypes)i)
            {
                case WeaponTypes.Pistol:
                    // Initialize pistol behavior and add to the array
                    break;
                case WeaponTypes.Rifle:
                    // Initialize rifle behavior and add to the array
                    break;
                case WeaponTypes.Shotgun:
                    // Initialize shotgun behavior and add to the array
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return result;
    }
}
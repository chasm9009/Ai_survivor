using System;

public static class InitBullets
{
    public static Delegate[] InitializeBulletBehaviors()
    {
        var result = new Delegate[Enum.GetValues(typeof(BulletTypes)).Length];
        for (int i = 0; i < result.Length; i++)
        {
            switch ((BulletTypes)i)
            {
                case BulletTypes.Pistol:
                    // Initialize pistol behavior and add to the array
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return result;
    }
}
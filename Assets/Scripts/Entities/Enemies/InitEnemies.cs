using System;

public static class InitEnemies
{
    public static Delegate[] InitializeEnemyBehaviors()
    {
        var result = new Delegate[EnemyTypes.GetValues(typeof(EnemyTypes)).Length];
        for (int i = 0; i < result.Length; i++)
        {
            switch ((EnemyTypes)i)
            {
                case EnemyTypes.grunt:
                    // Initialize grunt behavior and add to the array
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return result;
    }
}
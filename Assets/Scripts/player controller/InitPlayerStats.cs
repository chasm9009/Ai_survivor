public static class InitPlayerStats
{
    public static Stats InitializePlayerStats()
    {
        return new Stats
        {
            MaxHealth = 100,
            CurrentHealth = 100,
            MaxPower = 100,
            CurrentPower = 100,
            speed = 5,
            BaseDamage = 10,
            Range = 100,
            BulletSpeed = 20,
            fireRate = 1f,
            XP = 0,
            XPToNextLevel = 100,
            Level = 0
        };
    }
}
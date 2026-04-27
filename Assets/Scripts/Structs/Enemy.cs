using System.ComponentModel.DataAnnotations;
using UnityEngine;
public struct Enemy
{
    public EnemyTypes enemyType;
    public Stats stats;
    public int maxHealth;
    public int currentHealth;
    public int armor;
    public int speed;
    public int damage;
    public int range;
    public XpTypes xpType;
}
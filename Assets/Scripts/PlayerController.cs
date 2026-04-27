using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public WeaponTypes currentWeapon;
    public EnemyTypes currentEnemy;
    public BullitTypes currentBullit;

    void Start()
    {
        // Initialize player with default weapon, enemy, and bullit types
        currentWeapon = WeaponTypes.Pistol;
        currentEnemy = EnemyTypes.grunt;
        currentBullit = BullitTypes.Pistol;
        // Additional initialization code can go here
    }

    void Update()
    {
        // Handle player input and interactions here
    }
}
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private playerMovement player;

    [Header("Upgrade Buttons")]
    [SerializeField] private Button FireRateButton;
    [SerializeField] private Button SpeedButton;
    [SerializeField] private Button MaxHealthButton;
    [SerializeField] private Button DamageButton;

    [SerializeField] private HintQuizController hintQuizController;

    private void Start()
    {
        FireRateButton.onClick.AddListener(UpgradeFireRate);
        SpeedButton.onClick.AddListener(UpgradeSpeed);
        MaxHealthButton.onClick.AddListener(UpgradeMaxHealth);
        DamageButton.onClick.AddListener(UpgradeDamage);
    }

    private void UpgradeFireRate()
    {
        player.playerStats.fireRate *= 0.9f; // lower = faster fire rate
        CloseUpgradeScreen();
    }

    private void UpgradeSpeed()
    {
        //player.playerStats.speed *= 1.1f;
        CloseUpgradeScreen();
    }

    private void UpgradeMaxHealth()
    {
        player.playerStats.MaxHealth = (int)(player.playerStats.MaxHealth * 1.1f);
        player.playerStats.CurrentHealth = player.playerStats.MaxHealth; // heal to new max
        CloseUpgradeScreen();
    }

    private void UpgradeDamage()
    {
        player.playerStats.BaseDamage = (int)(player.playerStats.BaseDamage * 1.1f);
        CloseUpgradeScreen();
    }

    private void CloseUpgradeScreen()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
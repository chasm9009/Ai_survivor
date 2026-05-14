using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image healthImage;
    [SerializeField] private ThemeMusic themeMusic;

    [Header("Health Sprites")] 
    
    [SerializeField] private Sprite[] healthSprites; // array i stedet for individuelle sprites for hver health level
    
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthImage == null || healthSprites.Length == 0)
            return;

        float progress = (float)currentHealth / maxHealth;

        int spriteIndex = GetHealthIndex(progress);
        
        healthImage.sprite = healthSprites[spriteIndex];

        float reverse = 1f- progress;
        themeMusic.StartRinging(reverse);
    }

        private int GetHealthIndex(float progress)
    {
        if (progress >= 1f)
            return 4; // 100% health
        else if (progress >= 0.75f)
            return 3;    // 75% health
        else if (progress >= 0.50f)
            return 2; // 50% health
        else if (progress >= 0.25f)
            return 1; // 25% health
        else
            return 0; // 0% health
    }
}


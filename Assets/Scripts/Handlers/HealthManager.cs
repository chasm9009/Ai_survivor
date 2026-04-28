using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image healthImage;

    [Header("Health Sprites")]
    [SerializeField] private Sprite health0;
    [SerializeField] private Sprite health25;
    [SerializeField] private Sprite health50;
    [SerializeField] private Sprite health75;
    [SerializeField] private Sprite health100;

    void Start()
    {
        healthImage.sprite = health100;
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthImage == null)
            return;

        float progress = (float)currentHealth / maxHealth;

        if (progress >= 1f)
            healthImage.sprite = health100;
        else if (progress >= 0.75f)
            healthImage.sprite = health75;
        else if (progress >= 0.5f)
            healthImage.sprite = health50;
        else if (progress >= 0.25f)
            healthImage.sprite = health25;
        else
            healthImage.sprite = health0;
    }
}


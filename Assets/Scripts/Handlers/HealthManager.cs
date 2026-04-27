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

    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();
    }

    // Button helper: call this from a UI Button OnClick event
    public void TakeDamage25()
    {
        TakeDamage(25);
    }

    private void UpdateHealthBar()
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


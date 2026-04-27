using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthImage;

    public Sprite health100;
    public Sprite health75;
    public Sprite health50;
    public Sprite health25;
    public Sprite health0;

    private int currentHealth = 100;

    void Start()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (currentHealth > 75)
            healthImage.sprite = health100;
        else if (currentHealth > 50)
            healthImage.sprite = health75;
        else if (currentHealth > 25)
            healthImage.sprite = health50;
        else if (currentHealth > 0)
            healthImage.sprite = health25;
        else
            healthImage.sprite = health0;
    }
}
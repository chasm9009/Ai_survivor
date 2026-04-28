using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FMODUnity;

public class elonHealth : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image healthImage;
    [SerializeField] private elonattacks elonAttacks;

    [Header("Health Sprites")]
    [SerializeField] private Sprite health0;
    [SerializeField] private Sprite health25;
    [SerializeField] private Sprite health50;
    [SerializeField] private Sprite health75;
    [SerializeField] private Sprite health100;

    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 400;
    [SerializeField] private int currentHealth = 400;
    [SerializeField] SfxManager sfxManager;

    public bool isDead = false;
    public GameObject elonBoss;

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

    public void TakeDamage25()
    {
        if (currentHealth > 0)
            TakeDamage(25);
    }

    void Update()
    {
        UpdateHealthBar();
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("💀 ELON DEFEATED");
            elonAttacks.circleBurstActive = true;
            sfxManager.StopElonQuotes();
            elonDYING();
            elondeathsound();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthImage == null) return;

        float progress = (float)currentHealth / maxHealth;

        if (progress >= 1f)         healthImage.sprite = health100;
        else if (progress >= 0.75f) healthImage.sprite = health75;
        else if (progress >= 0.5f)  healthImage.sprite = health50;
        else if (progress >= 0.25f) healthImage.sprite = health25;
        else                        healthImage.sprite = health0;
    }

    public void elonDYING()
    {
        StartCoroutine(elonDisable());
    }

    IEnumerator elonDisable()
    {
        yield return new WaitForSeconds(1f);
        elonBoss.SetActive(false);
    }

    public void elondeathsound()
    {
        sfxManager.PlayElonDeath();
    }
}
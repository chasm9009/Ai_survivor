using System.Runtime.Serialization;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    public Stats playerStats;
    //insert Upgrades
    [SerializeField]
    private WeaponHandler weaponHandler;

    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] public InputActionReference moveInput;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private ScoreHolder scoreHolder;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HintQuizController hintQuizController;
    [SerializeField] private SfxManager sfxManager;

    // Update is called once per frame
    private void Update()
    {
        Vector2 moveDirection = moveInput.action.ReadValue<Vector2>();
        transform.Translate(new Vector2(moveDirection.x, moveDirection.y) * playerStats.speed * Time.deltaTime);

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = InitPlayerStats.InitializePlayerStats();
        weaponHandler = GetComponent<WeaponHandler>();
        weaponHandler.AddWeapon(WeaponTypes.Pistol);
    }
    Vector2 lastDirection;
    private void FixedUpdate()
    {
        if (moveInput.action.ReadValue<Vector2>() == Vector2.zero)
        {
            if (lastDirection == null || lastDirection == Vector2.zero)
            {
                weaponHandler.UpdateWeapons(playerStats, weaponHandler.bulletHandler, Time.fixedDeltaTime, Vector2.right);
                return;
            }
            weaponHandler.UpdateWeapons(playerStats, weaponHandler.bulletHandler, Time.fixedDeltaTime, lastDirection);
            return;
        }
        lastDirection = moveInput.action.ReadValue<Vector2>();
        weaponHandler.UpdateWeapons(playerStats, weaponHandler.bulletHandler, Time.fixedDeltaTime, lastDirection);
    }
    float timeSinceLastHit = 0f;
    public void TakeDamage(int damage)
    {
        if (Time.time - timeSinceLastHit < 1f)
        {
            return; // Player is still invulnerable, ignore damage
        }
        playerStats.CurrentHealth -= damage;
        playerStats.CurrentHealth = Mathf.Clamp(playerStats.CurrentHealth, 0, playerStats.MaxHealth);
        // Update health bar here if you have a reference to it
        Debug.Log("Damage " + damage);
        Debug.Log("CurrentHealth " + playerStats.CurrentHealth);
        Debug.Log("CurrentHealth " + playerStats.MaxHealth);
        healthBar.UpdateHealthBar(playerStats.CurrentHealth, playerStats.MaxHealth);
        if (playerStats.CurrentHealth <= 0)
        {
            // Handle player death (e.g., disable movement, play animation, etc.)
            Debug.Log("Player has died!");
            sfxManager.PlayPlayerDeath();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        timeSinceLastHit = Time.time; // Reset invulnerability timer
    }

    public void GainXP(float xp)
    {
        playerStats.XP += xp;
        if (playerStats.XP >= playerStats.XPToNextLevel)
        {
            LevelUp();
        }
        scoreHolder.UpdateXPBar(playerStats.Level, playerStats.XP, playerStats.XPToNextLevel);

    }
    public void LevelUp()
    {
        playerStats.CurrentHealth = playerStats.MaxHealth;
        playerStats.Level++;
        weaponHandler.AddBasedOnLevel(playerStats.Level);
        playerStats.XP = 0;
        playerStats.XPToNextLevel = playerStats.XPToNextLevel * 1.7f; // Increase target XP for next level
        // Here you can also increase player stats or unlock new abilities based on the new level
        hintQuizController.OnLevelUp();
        Debug.Log("Leveled Up! Current Level: " + playerStats.Level);
        sfxManager.PlayLevelUp();
    }
    public void OnDebugLevelUp()
    {
        LevelUp();
    }
}

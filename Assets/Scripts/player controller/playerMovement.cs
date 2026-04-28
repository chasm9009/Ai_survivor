using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    private Stats playerStats;
    //insert Upgrades
    [SerializeField]
    private WeaponHandler weaponHandler;

    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] public InputActionReference moveInput;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    private void Update()
    {
        Vector2 moveDirection = moveInput.action.ReadValue<Vector2>();
        transform.Translate(new Vector2(moveDirection.x, moveDirection.y) * speed * Time.deltaTime);

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
                return; // No movement and no last direction, so skip firing
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
        if (playerStats.CurrentHealth <= 0)
        {
            // Handle player death (e.g., disable movement, play animation, etc.)
            Debug.Log("Player has died!");
        }
        timeSinceLastHit = Time.time; // Reset invulnerability timer
    }
}

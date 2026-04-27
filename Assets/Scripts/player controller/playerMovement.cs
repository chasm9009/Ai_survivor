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
    private void FixedUpdate()
    {
        if (moveInput.action.ReadValue<Vector2>() == Vector2.zero)
        {
            weaponHandler.UpdateWeapons(playerStats, weaponHandler.bulletHandler, Time.fixedDeltaTime, Vector2.right);
            return;
        }
        weaponHandler.UpdateWeapons(playerStats, weaponHandler.bulletHandler, Time.fixedDeltaTime, moveInput.action.ReadValue<Vector2>());
    }
}

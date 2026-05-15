using UnityEngine;
using UnityEngine.Events;
public class MarkBossHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public int maxHealth = 400;
    [SerializeField] public int currentHealth = 400;
    [SerializeField] private BulletHandler bulletHandler;
    [SerializeField] private MarkBossHealthBar healthBar;
    public UnityEvent <int, int> onHealthChanged = new UnityEvent<int, int>();
    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged.AddListener(healthBar.UpdateHealthBar);
        onHealthChanged.Invoke(currentHealth, maxHealth);
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
        }
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        onHealthChanged.Invoke(currentHealth, maxHealth);
    }

    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Bullet hit mark");
            bulletHandler.DespawnBullet(collision.gameObject);
            var bulletComponent = collision.gameObject.GetComponent<Bullet>();

            TakeDamage(bulletComponent.damage);
        }
    } 
}
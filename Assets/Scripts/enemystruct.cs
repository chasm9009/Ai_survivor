using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystruct : MonoBehaviour
{
    public EnemyStats enemyStats;
    public GameObject player;
    public Rigidbody2D enemybody;
    [SerializeField] private float speed = 0.003f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public EnemyHandler enemyHandler;
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject;
        }
        enemyHandler = FindObjectOfType<EnemyHandler>();
    }
    public void InitializeEnemy(EnemyStats stats)
    {
        enemyStats = stats;
        Debug.Log($"Initialized enemy with type {enemyStats.enemyType} and health {enemyStats.currentHealth}");
    }
    void FixedUpdate()
    {
        float direction = player.transform.position.x - transform.position.x;
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy hit something");
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Bullet hit enemy");
            //get bullet manager component and call despawn bullet function
            BulletHandler bulletHandler = FindObjectOfType<BulletHandler>();
            bulletHandler.DespawnBullet(collision.gameObject);
            var bulletComponent = collision.gameObject.GetComponent<Bullet>();

            enemyStats.currentHealth -= bulletComponent.damage;
            if (enemyStats.currentHealth <= 0)
            {
                enemyHandler.DespawnEnemy(gameObject);
            }
        }
    }
}

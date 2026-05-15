using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class MarkBossAttack : MonoBehaviour
{
[SerializeField] private MarkBossController controller;

[Header("Circle Attack Settings")]
[SerializeField] private float projectileSpeed = 8f;
[SerializeField] private float projectileLifetime = 1.5f;
[SerializeField] private float delayBetweenShots = 0.2f;
[SerializeField] private GameObject projectilePrefab;
[SerializeField] private int poolSize = 20;
[Header("Melee Attack settings")]
[SerializeField] private int meleeDamage = 30;
[SerializeField] private int damage = 30;
[SerializeField] private float damageCooldown = 1f;
private float lastDamageTime;
// below we are setting up the object pool for circle attack and all its functions.
private ObjectPool<GameObject> projectilePool;
    void Start()
    {
        projectilePool = new ObjectPool<GameObject>(
            CreateProjectile,
            UseProjectile,
            OnReturnProjectile,
            OnDestroyProjectile,
            defaultCapacity: poolSize,
            maxSize: poolSize * 2
        );
    } 
    private GameObject CreateProjectile()
    {
        GameObject Projectile = Instantiate(projectilePrefab);
        Projectile.SetActive(false);
        return Projectile;
    }
    private void UseProjectile(GameObject projectile)
    {
        projectile.SetActive(true);
    }

    private void OnReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
    }
    private void OnDestroyProjectile(GameObject projectile)
    {
        Destroy(projectile);
    }

// Below is all attacks, they get called from the controller.

    public void CircleAttack()
    {
        StartCoroutine(CircleAttackRoutine());
    }

    private IEnumerator CircleAttackRoutine()
    {
        float angleStep = 360f / poolSize;
        for (int i = 0; i < poolSize; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            FireProjectile(direction);
            yield return new WaitForSeconds(delayBetweenShots);
        }
        controller.ResetAttack();
    }
   void FireProjectile(Vector2 direction)
    {
    GameObject projectile = projectilePool.Get();
    projectile.transform.position = transform.position;
    MarkBossCircleBullet bullet = projectile.GetComponent<MarkBossCircleBullet>();
    bullet.InitializeShot(projectilePool, direction * projectileSpeed, projectileLifetime);
    }

// Melee attack
  public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           if (Time.time - lastDamageTime >= damageCooldown)
        {
            lastDamageTime = Time.time;
            collision.GetComponent<playerMovement>().TakeDamage(meleeDamage);
        }
        }
    } 
}


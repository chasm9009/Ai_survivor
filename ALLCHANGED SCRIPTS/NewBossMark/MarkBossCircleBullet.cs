using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class MarkBossCircleBullet : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    private ObjectPool<GameObject> prefabPool;
    public void InitializeShot(ObjectPool<GameObject> pool, Vector2 velocity, float lifetime)
    {
        prefabPool = pool;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = velocity;

        StartCoroutine(ReturnAfterTime(lifetime));
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

   public void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        playerMovement player = collision.GetComponent<playerMovement>();
        player.TakeDamage(damage);
        prefabPool.Release(gameObject);
    }
}

    IEnumerator ReturnAfterTime(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        prefabPool.Release(gameObject);
    }
    }

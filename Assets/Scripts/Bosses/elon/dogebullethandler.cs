using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class dogebullethandler : MonoBehaviour
{
    private ObjectPool<GameObject> pool;

    private playerMovement playerMovement;
    public void Start()
    {
        playerMovement = FindAnyObjectByType<playerMovement>();
    }
    public void Init(ObjectPool<GameObject> poolRef, Vector2 velocity, float lifetime)
    {
        pool = poolRef;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = velocity;

        StartCoroutine(ReturnAfterTime(lifetime));
    }

    IEnumerator ReturnAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        pool.Release(gameObject);
    }
    void Update()
    {
        if (CompareTag("Player"))
        {
            pool.Release(gameObject);
        }
    }
    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.TakeDamage(10);
        }
    }
}
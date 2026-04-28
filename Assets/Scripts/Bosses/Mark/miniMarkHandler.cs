using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class miniMarkhandler : MonoBehaviour
{
    private ObjectPool<GameObject> pool;

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
}
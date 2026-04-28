using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;

public class elonattacks : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    [SerializeField] private GameObject dogecoinPrefab;

    [Header("Attack Settings")]
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private int projectileCount = 20;
    [SerializeField] private float delayBetweenShots = 0.1f;
    [SerializeField] private float projectileLifetime = 1.5f;

    public bool specialAttack = true;

    private ObjectPool<GameObject> dogecoinPool;

    public GameObject dogecoinshooter;
    public elonmovement elonmovement;

    public bool circleBurstActive = false;

    void Awake()
    {
        dogecoinPool = new ObjectPool<GameObject>(
            CreateCoin,
            OnTakeCoin,
            OnReturnCoin,
            OnDestroyCoin,
            collectionCheck: false,
            defaultCapacity: 20,
            maxSize: 50
        );
    }

    void Update()
    {
        if (Random.Range(0f, 1f) > 0.995f && !circleBurstActive) // Random chance to trigger special attack, only if not already active
        {
            circleBurstActive = true;
            Debug.Log("🚀 SPECIAL ATTACK: CIRCLE BURST");
            CircleBurstAttack();
        }

        if (Random.Range(0f, 1f) > 0.995f && !circleBurstActive) // Random chance to trigger special attack, only if not already active)
        {
            circleBurstActive = true;
            Debug.Log("🚀 SPECIAL ATTACK: FULL ELECTRIC BOOST");
            SpeedBoost();
        }
    }

    // ================================
    // ATTACK
    // ================================

    public void CircleBurstAttack()
    {
        StartCoroutine(CircleBurstRoutine());
    }

    IEnumerator CircleBurstRoutine()
    {
        elonmovement.dashSpeed = 0f;
        float angleStep = 360f / projectileCount;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

            FireProjectile(direction);

            yield return new WaitForSeconds(delayBetweenShots);
        }
         elonmovement.dashSpeed = 15f;
         circleBurstActive = false;
    }

    void FireProjectile(Vector2 direction)
{
    GameObject coin = dogecoinPool.Get();

    coin.transform.position = transform.position;

        dogebullethandler bullet = coin.GetComponent<dogebullethandler>();
        bullet.Init(dogecoinPool, direction * projectileSpeed, projectileLifetime);
}

    IEnumerator ReturnToPoolAfterTime(GameObject coin, float time)
    {
        yield return new WaitForSeconds(time);

        dogecoinPool.Release(coin);
    }

    // ================================
    // OBJECT POOL
    // ================================

    GameObject CreateCoin()
    {
        GameObject coin = Instantiate(dogecoinPrefab);
        return coin;
    }

    void OnTakeCoin(GameObject coin)
    {
        coin.SetActive(true);
    }

    void OnReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
    }

    void OnDestroyCoin(GameObject coin)
    {
        Destroy(coin);
    }

    // NEXT ATTACK Complete speed boost!

    public void SpeedBoost()
    {
        StartCoroutine(SpeedBoostRoutine());
    }

    IEnumerator SpeedBoostRoutine()
    {
        elonmovement.dashChance = 0.1f;
        for (int i = 0; i < 3; i++)
        {
            elonmovement.dashSpeed += 5f;
            yield return new WaitForSeconds(0.5f);
        }
        elonmovement.dashChance = 0.995f;
        elonmovement.dashSpeed = 15f;
        circleBurstActive = false;
    }
}
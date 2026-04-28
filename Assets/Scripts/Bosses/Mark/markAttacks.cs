using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;

public class markAttacks : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    [SerializeField] private GameObject miniMarkPrefab;

    [Header("Attack Settings")]
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private int projectileCount = 20;
    [SerializeField] private float delayBetweenShots = 0.1f;
    [SerializeField] private float projectileLifetime = 1.5f;
    [SerializeField] SfxManager sfxManager;

    [Header("Voiceline Settings")]
    [SerializeField] private float voicelineCooldown = 3f;
    private float lastVoicelineTime = -4f;

    public bool specialAttack = true;

    private ObjectPool<GameObject> miniMarkPool;

    public GameObject miniMarkShooter;
    public markMovement markMovement;

    public bool circleBurstActive = false;

    void Awake()
    {
        miniMarkPool = new ObjectPool<GameObject>(
            CreateMiniMark,
            OnTakeMiniMark,
            OnReturnMiniMark,
            OnDestroyMiniMark,
            collectionCheck: false,
            defaultCapacity: 20,
            maxSize: 50
        );
    }

    void Update()
    {
        if (Random.Range(0f, 1f) > 0.995f && !circleBurstActive)
        {
            circleBurstActive = true;
            TryPlayVoiceline();
            Debug.Log("🚀 SPECIAL ATTACK: CIRCLE BURST");
            CircleBurstAttack();
        }

        if (Random.Range(0f, 1f) > 0.995f && !circleBurstActive)
        {
            circleBurstActive = true;
            TryPlayVoiceline();
            Debug.Log("🚀 SPECIAL ATTACK: FULL ELECTRIC BOOST");
            SpeedBoost();
        }
    }

    void TryPlayVoiceline()
    {
        if (Time.time - lastVoicelineTime >= voicelineCooldown)
        {
            sfxManager.PlayMarkQuotes();
            lastVoicelineTime = Time.time;
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
        markMovement.dashSpeed = 0f;
        float angleStep = 360f / projectileCount;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

            FireProjectile(direction);

            yield return new WaitForSeconds(delayBetweenShots);
        }
        markMovement.dashSpeed = 15f;
        circleBurstActive = false;
    }

    void FireProjectile(Vector2 direction)
    {
        GameObject miniMark = miniMarkPool.Get();

        miniMark.transform.position = transform.position;

        miniMarkhandler bullet = miniMark.GetComponent<miniMarkhandler>();
        bullet.Init(miniMarkPool, direction * projectileSpeed, projectileLifetime);
    }

    IEnumerator ReturnToPoolAfterTime(GameObject miniMark, float time)
    {
        yield return new WaitForSeconds(time);

        miniMarkPool.Release(miniMark);
    }

    // ================================
    // OBJECT POOL
    // ================================

    GameObject CreateMiniMark()
    {
        GameObject miniMark = Instantiate(miniMarkPrefab);
        return miniMark;
    }

    void OnTakeMiniMark(GameObject miniMark)
    {
        miniMark.SetActive(true);
    }

    void OnReturnMiniMark(GameObject miniMark)
    {
        miniMark.SetActive(false);
    }

    void OnDestroyMiniMark(GameObject miniMark)
    {
        Destroy(miniMark);
    }

    // ================================
    // SPEED BOOST
    // ================================

    public void SpeedBoost()
    {
        StartCoroutine(SpeedBoostRoutine());
    }

    IEnumerator SpeedBoostRoutine()
    {
        markMovement.dashChance = 0.1f;
        for (int i = 0; i < 3; i++)
        {
            markMovement.dashSpeed += 5f;
            yield return new WaitForSeconds(0.5f);
        }
        markMovement.dashChance = 0.995f;
        markMovement.dashSpeed = 15f;
        circleBurstActive = false;
    }
}
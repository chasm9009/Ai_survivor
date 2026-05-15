using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class elonattacks : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Boss Sprite")]
    [SerializeField] public SpriteRenderer bossRenderer;
    [SerializeField] public Sprite elonSprite;

    [Header("Attack Settings")]
    [SerializeField] private GameObject dogecoinPrefab;
    [SerializeField] private float projectileSpeed = 8f;
    [SerializeField] private int projectileCount = 20;
    [SerializeField] private float delayBetweenShots = 0.1f;
    [SerializeField] private float projectileLifetime = 1.5f;
    [SerializeField] private SfxManager sfxManager;

    [Header("Voiceline Settings")]
    [SerializeField] private float voicelineCooldown = 3f;
    private float lastVoicelineTime = -4f;

    public bool specialAttack = true;
    public bool circleBurstActive = false;
    private bool spriteSet = false;

    private ObjectPool<GameObject> dogecoinPool;

    public GameObject dogecoinshooter;
    public elonmovement elonmovement;

    void Awake()
    {
        EnforceElonSprite();

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

    void Start()
    {
        EnforceElonSprite();
    }

    void Update()
    {
        if (!spriteSet)
        {
            EnforceElonSprite();
            spriteSet = true;
        }

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

    private void EnforceElonSprite()
    {
        if (bossRenderer != null && elonSprite != null)
            bossRenderer.sprite = elonSprite;
    }

    void TryPlayVoiceline()
    {
        if (Time.time - lastVoicelineTime >= voicelineCooldown)
        {
            sfxManager.PlayElonQuotes();
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

    // ================================
    // OBJECT POOL
    // ================================

    GameObject CreateCoin()
    {
        return Instantiate(dogecoinPrefab);
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

    // ================================
    // SPEED BOOST
    // ================================

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
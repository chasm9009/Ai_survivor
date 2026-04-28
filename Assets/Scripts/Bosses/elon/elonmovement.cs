using System.Collections;
using UnityEngine;

public class elonmovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] public float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] public float dashChance = 0.995f;
    [SerializeField] private float yTeleportThreshold;

    public elonattacks elonattacks;

    [SerializeField] private elonHealth elonHealth;
    [SerializeField] private playerMovement playerMovement;

    private bool isDashing = false;

    void Update()
    {
        float yDistance = Mathf.Abs(transform.position.y - player.transform.position.y);

        if (yDistance > yTeleportThreshold)
        {
            TeleportToPlayer();
            {
                float side = Random.value > 0.5f ? 1f : -1f;
                float xOffset = side * Random.Range(5f, 15f);

                transform.position = new Vector3(
                    player.transform.position.x + xOffset,
                    player.transform.position.y,
                    transform.position.z
                );
                Debug.Log($"📡 STARLINK TELEPORT — new X: {transform.position.x}");
            }
        }

        float direction = player.transform.position.x - transform.position.x;

        // Always face player
        spriteRenderer.flipX = direction >= 0;

        float distance = Mathf.Abs(direction);

        if (!isDashing && distance < 80f && Random.value > dashChance)
        {
            StartCoroutine(Dash(Mathf.Sign(direction)));
        }
    }

    void TeleportToPlayer()
    {
        transform.position = new Vector3(
            transform.position.x,
            player.transform.position.y,
            transform.position.z
        );
    }

    IEnumerator Dash(float moveDir)
    {
        isDashing = true;

        Debug.Log("💨 DASH");

        float timer = 0f;

        while (timer < dashDuration)
        {
            transform.position += new Vector3(
                moveDir * dashSpeed * Time.deltaTime,
                0f,
                0f
            );

            timer += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Bullet hit elon");
            //get bullet manager component and call despawn bullet function
            BulletHandler bulletHandler = FindObjectOfType<BulletHandler>();
            bulletHandler.DespawnBullet(collision.gameObject);
            var bulletComponent = collision.gameObject.GetComponent<Bullet>();

            elonHealth.TakeDamage(bulletComponent.damage);
        }
    }
    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damagePlayer(30);
        }
    }
    private void damagePlayer(int damage)
    {
        playerMovement.TakeDamage(damage);
    }
}
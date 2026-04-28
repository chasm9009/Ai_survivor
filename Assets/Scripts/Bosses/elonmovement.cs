using System.Collections;
using UnityEngine;

public class elonmovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] public float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] public float dashChance = 0.995f;
    [SerializeField] private float yTeleportThreshold = 5f;

    public elonattacks elonattacks;

    private bool isDashing = false;

    void Update()
    {
        float yDistance = Mathf.Abs(transform.position.y - player.transform.position.y);

        if (yDistance > yTeleportThreshold)
        {
            TeleportToPlayer();
            if (Random.Range(0f, 1f) > 0.99f)
            {
                Debug.Log("ELON USED STARLINK TO TELEPORT TO PLAYER WATCH OUT HE IS EXTRA FAST AND MAD");
                elonattacks.SpeedBoost();
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
}
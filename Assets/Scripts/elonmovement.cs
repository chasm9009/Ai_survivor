using System.Collections;
using UnityEngine;

public class elonmovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] private float dashChance = 0.995f;

    private bool isDashing = false;

    void Update()
    {
        float direction = player.transform.position.x - transform.position.x;

        // Always face player
        spriteRenderer.flipX = direction >= 0;

        float distance = Mathf.Abs(direction);

        // ONLY try to dash, no constant movement
        if (!isDashing && distance < 80f && Random.value > dashChance)
        {
            StartCoroutine(Dash(Mathf.Sign(direction))); // Dash towards player work by using the sign of the direction to determine left or right
        }
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
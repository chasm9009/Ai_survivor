using System.Collections;
using UnityEngine;
public class MarkBossMovement : MonoBehaviour
{
[SerializeField] private MarkBossController controller; // Lets see if there is a way to do isAttacking without having to reference the controller, but for now this is fine
[SerializeField] private SpriteRenderer spriteRenderer;
[SerializeField] private float moveSpeed = 10f;
[SerializeField] private float teleportDistance = 20f;
[SerializeField] private float teleportOffSet = 20f;
[SerializeField] private float stopDistance = 3f;
private bool isDashing = false;

public float GetDirection(float playerX)
    {
        return playerX - transform.position.x;
    }
public void FacePlayer(float playerX) //Called in controller, makes sure boss is always facing player
    {
        spriteRenderer.flipX = GetDirection(playerX) >= 0;
    }
public void MoveTowardsPlayer(float playerX)
    {
        if (Mathf.Abs(GetDirection(playerX)) < stopDistance) return;
        transform.position += new Vector3(Mathf.Sign(GetDirection(playerX)) * moveSpeed * Time.fixedDeltaTime, 0, 0);
    }

public void TeleportTowardsPlayer(Vector3 playerPosition)
    {
        float distanceToPlayer = Mathf.Abs(transform.position.y - playerPosition.y);
        if (distanceToPlayer > teleportDistance)
        {
        float sideOffSet = Random.Range(-teleportOffSet, teleportOffSet);
        transform.position = new Vector3(
            playerPosition.x + sideOffSet,
            playerPosition.y,
            transform.position.z);
        }
    }

public void DashAttack()
    {
        if (!isDashing)
        {
            StartCoroutine(Dash());
        }
        controller.ResetAttack();
    }

IEnumerator Dash()
    {
        float originalMoveSpeed = moveSpeed;
        isDashing = true;
        for (int i = 0; i < 20; i++)
        {
           moveSpeed *= 1.2f;
           yield return new WaitForSeconds(0.03f);
        }
        moveSpeed = originalMoveSpeed;
        isDashing = false;
        controller.ResetAttack();
    }
 }

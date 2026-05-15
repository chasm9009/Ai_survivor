using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarkBossController : MonoBehaviour
{
[SerializeField] private SfxManager sfxManager;
[SerializeField] private MarkBossMovement mMovement;
[SerializeField] private MarkBossHealth mHealth;
[SerializeField] private MarkBossAttack mAttacks;
[SerializeField] private float CircleAttackChance = 0.955f;
[SerializeField] private float SpeedAttackChance = 0.05f;
public GameObject player;
public bool isAttacking = false; // so he doesn't spam attacks, can only do one at a time
private bool deadLock = false; // so death function only triggers once

    void FixedUpdate()
    {
        float attackChance = Random.Range(0f, 1f);
        Debug.Log("Attack Chance: " + attackChance);
        if (attackChance > CircleAttackChance && !isAttacking)
        {
           isAttacking = true;
           sfxManager.TryPlayVoiceline(0); // Mark is boss index 0, (Elon is 1)
           Debug.Log("Circle Attack Triggered");
           mAttacks.CircleAttack();
        }
        else if (attackChance < SpeedAttackChance && !isAttacking)
        {
            isAttacking = true;
            sfxManager.TryPlayVoiceline(0);
            Debug.Log("Speed Attack Triggered");
            mMovement.DashAttack();
        }
        mMovement.FacePlayer(player.transform.position.x);
        mMovement.MoveTowardsPlayer(player.transform.position.x);
        mMovement.TeleportTowardsPlayer(player.transform.position);

        if (mHealth.isDead && !deadLock) //this means a tiny delay on death but should be fine
        {
            deadLock = true;
            markDYING();
        }
    }
    public void ResetAttack()
    {
        isAttacking = false;
    }

    public void markDYING()
    {
        mMovement.StopAllCoroutines(); // Stop any ongoing dash
        mAttacks.StopAllCoroutines(); // Stop any ongoing attacks
        StartCoroutine(markDisable());
    }

    IEnumerator markDisable()
    {
        markdeathsound();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void markdeathsound()
    {
        sfxManager.PlayMarkDeath();
    }

    public void spawnMark()
    {
        gameObject.SetActive(true);
        mHealth.currentHealth = mHealth.maxHealth;
        mHealth.onHealthChanged.Invoke(mHealth.currentHealth, mHealth.maxHealth);
    }
}
 
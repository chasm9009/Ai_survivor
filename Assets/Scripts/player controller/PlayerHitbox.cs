using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitbox : MonoBehaviour
{
    [SerializeField]
    private playerMovement playerMovement;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats == null)
            {
                return;
            }
            playerMovement.TakeDamage(enemyStats.damage);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats == null)
            {
                return;
            }
            playerMovement.TakeDamage(enemyStats.damage);
        }
    }
}

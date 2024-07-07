using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int HitDamage = 5;
    [SerializeField] private int currentHealth;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void Attack()
    {
        SoundManager.PlaySound(soundType.ATTACK);

        Debug.Log("Player Attacking");

        // Gets all enemies around, and calls Take Damage on each
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            var enemyScript = enemy.gameObject.GetComponent<Enemy>();
            if (enemyScript.IsAlive)
            {
                enemyScript.TakeDamage(HitDamage);
                Debug.Log("We hit" + enemy.name);
            }
        }
    }
    
    public void GotHit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: respawn
        Debug.Log("Player died");
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
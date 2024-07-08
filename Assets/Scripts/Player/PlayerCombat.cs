using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] public int MaxHealth;
    [SerializeField] private int HitDamage;
    [SerializeField] public int currentHealth;
    public Transform attackPoint;
    public float attackRange;
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
        
        PlayerUI.Instance.onGetHit.Invoke(damage);
        
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
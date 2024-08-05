//using System.Collections;
//using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TestTowerDefence : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private Enemy enemy;
    private bool isCollided;
    public bool isDestroyed;
    [SerializeField] private Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isDestroyed = false;
        isCollided = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);
        Debug.Log("Damage taken is: " + enemy.damage);

        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        isDestroyed=true;
        animator.Play("TowerExplosion");
        Debug.Log("Tower has been destroyed");
        StopAllCoroutines();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCollided)
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                StartCoroutine(TakeDamageOverTime());
            }
        }
    }

    private IEnumerator TakeDamageOverTime()
    {
        isCollided = true;

        while (currentHealth > 0)
        {
            TakeDamage(enemy.damage);
            yield return new WaitForSeconds(enemy.damageInterval);
        }

        isCollided = false;
    }

}

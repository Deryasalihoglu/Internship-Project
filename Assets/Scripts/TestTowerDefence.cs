//using System.Collections;
//using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TestTowerDefence : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    public bool isDestroyed;
    [SerializeField] private Animator animator;

    void Start()
    {
        isDestroyed = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);
        Debug.Log("Damage taken is: " + damage);

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
        GameController.Instance.OnTowerDestroyed();
    }

}

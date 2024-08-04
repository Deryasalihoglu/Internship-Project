using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerDefence : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField] bool isCollided;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0) 
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Debug.Log("Tower has been destroyed");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //isCollided = true;
        TakeDamage(20); // Tek vuruþta kule yýkýlacak 
        Debug.Log("20 damage verildi");
    }
}

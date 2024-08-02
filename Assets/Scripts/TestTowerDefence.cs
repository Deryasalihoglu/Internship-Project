using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerDefence : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Max health" + healthBar.getMaxHealth());
        //Debug.Log("Current health" + healthBar.getCurrentHealth());
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.setMaxHealth(currentHealth);

        if (currentHealth <= 0) 
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Debug.Log("Tower has been destroyed");
    }
}

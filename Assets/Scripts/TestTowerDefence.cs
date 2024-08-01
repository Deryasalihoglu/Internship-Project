using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerDefence : MonoBehaviour
{

    private int maxHealth = 100;
    private int currentHealth;
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  // When the game starts, the tower will have max health.
        healthBar.SetHealth(maxHealth); //and health bar will show it.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMaxHealth() { return maxHealth; }
    public int GetCurrentHealth() { return currentHealth; }

    public void TakaDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}

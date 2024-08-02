using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private int maxHealth;
    private int minHealth;
    private int currentHealth;

    public HealthBar()
    {
        maxHealth = 100;
        minHealth = 0;
        currentHealth = 100;
        slider.maxValue = 100;
        slider.value = 100;
    }

    public void setMaxHealth(int health) 
    {
        maxHealth = health;
        slider.maxValue = health;
        slider.value = health;
    }

    public void setCurrentHealth(int health)
    {
        currentHealth = health;
        slider.value = health; 
    }

    public void setMinHealth(int health)
    {  
        minHealth = health;
        slider.minValue = health;
    }

    public void takeDamage(int damage)
    {
        if (slider.value > 0 && slider.value >= damage)
        {
            slider.value -= damage;
            currentHealth -= damage;
        }

        else if (slider.value > 0 && slider.value < damage)
        {
            slider.value = 0;
            currentHealth = 0;
        }
    }

    public int getMaxHealth() { return maxHealth; }
    public int getMinHealth() { return minHealth; }
    public int getCurrentHealth() { return currentHealth; }

}

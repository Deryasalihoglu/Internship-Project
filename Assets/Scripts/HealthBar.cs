using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private float maxHealth;


    void Start()
    {

    }

    public void SetMaxHealth(float health) 
    {
        maxHealth = health;
    }

    public void SetCurrentHealth(float health)
    {
        float normalizedHealth = Mathf.Clamp(health / maxHealth, 0, 1);
        slider.value = normalizedHealth;
    }

}

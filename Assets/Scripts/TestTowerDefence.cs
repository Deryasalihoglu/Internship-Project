using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerDefence : MonoBehaviour
{
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        this.healthBar = gameObject.AddComponent<HealthBar>();  // When the game starts, the tower will have health bar with max value.
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Max health" + healthBar.getMaxHealth());
        //Debug.Log("Current health" + healthBar.getCurrentHealth());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 5;
    public float arrowDamage = 4;
    public float arrowAttackCooldown = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Enemy victimEnemy = collision.gameObject.GetComponent<Enemy>(); //!!!!!!!!!!!!!!!!!!!
            arrowSpeed = 0;
            victimEnemy.TakeDamage(arrowDamage);
        }
    }
}

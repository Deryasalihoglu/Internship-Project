//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3;
    public float damage = 5;
    public float attackCooldown = 0.21f;
    private bool isCollided;
    private float timeSinceLastAttack;
    public TestTowerDefence tower;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    void Start()
    {
        animator.SetFloat("speed", speed);
        GameController.Instance.OnTowerDestroyed += OnTowerDestroyed;
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + new Vector3(-speed * Time.fixedDeltaTime, 0f, 0f));
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack > attackCooldown)
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            isCollided = true;
            speed = 0;
            animator.SetFloat("speed", 0);
        }
    }

    private void Attack()
    {
        if (!tower.isDestroyed && isCollided)
        {
            animator.Play("GoblinAttack_1");
            timeSinceLastAttack = 0;
            tower.TakeDamage(damage);
        }
    }

    private void OnTowerDestroyed()
    {
        isCollided = false;
        animator.Play("GoblinIdle");
    }
}

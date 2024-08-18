using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3;
    public float damage = 5;
    public float currentHealth = 20;
    public float attackCooldown = 0.21f;
    private bool isCollided;
    private float timeSinceLastAttack;
    public EnemyPool enemyPool;
    [HideInInspector] public Tower tower;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    void Start()
    {
        animator.SetFloat("speed", speed);
        GameController.Instance.OnTowerDestroyed += OnTowerDestroyed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(-speed * Time.fixedDeltaTime, 0f, 0f));
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
            animator.SetBool("isAttacking", true);
        }
    }

    private void Attack()
    {
        if (isCollided && !tower.isDestroyed)
        {
            timeSinceLastAttack = 0;
            tower.TakeDamage(damage);
        }
    }

    private void OnTowerDestroyed()
    {
        isCollided = false;
        animator.SetBool("isAttacking", false);
        animator.Play("GoblinIdle");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            enemyPool.AddDefeatedEnemyToPool(this);
        }
    }
}

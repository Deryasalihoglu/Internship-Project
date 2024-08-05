//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float damage;
    public float damageInterval;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        damage = 5;
        damageInterval = 0.21f;
        speed = 3;
        animator.SetFloat("speed", 3);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + new Vector3(-speed * Time.fixedDeltaTime, 0f, 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            speed = 0;
            animator.SetFloat("speed", 0);
            animator.Play("GoblinAttack_1");
        }
    }

}

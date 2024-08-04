using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        speed = 3;
        animator.SetFloat("speed", 3);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + new Vector3(-speed * Time.fixedDeltaTime, 0f, 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tower")
        {
            speed = 0;
            animator.SetFloat("speed", 0);
            animator.Play("GoblinAttack_1");
        }
    }
}

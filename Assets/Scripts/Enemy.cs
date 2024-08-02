using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rigidbody;
    private Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        speed = 3;
        animator.SetFloat("speed", 3);
        rigidbody.velocity = new Vector2((-1 * speed),0f);
    }
}

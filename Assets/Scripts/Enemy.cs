using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    void Start()
    {
        speed = 3;
        animator.SetFloat("speed", 3);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + new Vector3(-speed * Time.fixedDeltaTime, 0f, 0f));
    }
}

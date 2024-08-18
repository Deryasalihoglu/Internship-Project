using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] Arrow arrow;
    [SerializeField] private Rigidbody2D arrowRB;
    private Vector3 targetPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootArrow();
        }
    }
    public void ShootArrow()
    {
        targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPoint.z = 0;
        Vector3 direction = (targetPoint - transform.position).normalized;
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrow.arrowSpeed;
        //this.arrowRB.MovePosition(transform.position + new Vector3(10f * Time.fixedDeltaTime, 0f));
    }
}

using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 5;
    public int arrowDamage = 4;
    public float arrowLifeTime = 3f;
    private ArrowPool pool;
    [SerializeField] private Rigidbody2D arrowRB;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Enemy victimEnemy = collision.gameObject.GetComponent<Enemy>();
            victimEnemy.TakeDamage(arrowDamage);
            pool.AddInactiveArrowToThePool(this);
        }

        else if(collision.gameObject.CompareTag("Ground"))
        {
            pool.AddInactiveArrowToThePool(this);
        }
    }

    public void OnFired(Vector3 direction)
    {
        arrowRB.velocity = direction.normalized * arrowSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        //transform.rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Euler(0, 0, -90); // HACK
    }


    public void SetPool(ArrowPool pool)
    {
        this.pool = pool;
    }
}

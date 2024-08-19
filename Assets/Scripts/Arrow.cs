using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 5;
    public int arrowDamage = 4;
    public float arrowLifeTime = 3f;
    [SerializeField] private Rigidbody2D arrowRB;
    private ArrowPool pool;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Enemy victimEnemy = collision.gameObject.GetComponent<Enemy>();
            victimEnemy.TakeDamage(arrowDamage);
            pool.AddInactiveArrowToThePool(this);
        }
    }

    public void OnFired(Vector3 direction)
    {
        arrowRB.velocity = direction.normalized * arrowSpeed;
        transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0,0,-90);
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z); // HACK
    }


    public void SetPool(ArrowPool pool)
    {
        this.pool = pool;
    }
}

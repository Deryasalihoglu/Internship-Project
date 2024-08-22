using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Vector3 targetPoint;
    private ArrowPool arrowPool;
    private float timeSinceLastArrowSpawn;
    [SerializeField] private float arrowCooldown = 0.5f;
    [SerializeField] private Arrow arrow;
    [SerializeField] private GameObject originPoint;
    [SerializeField] private Transform arrowContainer;

    private void Start()
    {
        arrowPool = new ArrowPool(arrow, originPoint, arrowContainer);
    }

    private void Update()
    {
        timeSinceLastArrowSpawn += Time.deltaTime;
        if (Input.touchCount > 0 && timeSinceLastArrowSpawn > arrowCooldown)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ShootArrow(touch);
            }
        }
    }

    public void ShootArrow(Touch touch)
    {
        targetPoint = Camera.main.ScreenToWorldPoint(touch.position);
        targetPoint.z = 0;
        Vector3 origin = originPoint.transform.position;
        origin.z = 0;
        arrow = arrowPool.GetArrow();
        Vector3 direction = targetPoint - origin;
        arrow.OnFired(direction);
        timeSinceLastArrowSpawn = 0;
    }
}

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
        if (timeSinceLastArrowSpawn > arrowCooldown)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ShootArrow(Input.GetTouch(0).position);
            }
            else if (Input.GetMouseButton(0))
            {
                ShootArrow(Input.mousePosition);
            }
        }
    }

    public void ShootArrow(Vector3 targetPosition)
    {
        targetPoint = Camera.main.ScreenToWorldPoint(targetPosition);
        targetPoint.z = 0;
        Vector3 origin = originPoint.transform.position;
        origin.z = 0;
        arrow = arrowPool.GetArrow();
        Vector3 direction = targetPoint - origin;
        arrow.OnFired(direction);
        timeSinceLastArrowSpawn = 0;
    }
}

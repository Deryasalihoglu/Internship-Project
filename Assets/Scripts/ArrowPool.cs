using System.Collections.Generic;
using UnityEngine;

public class ArrowPool
{
    private Arrow arrowPrefab;
    private GameObject originPoint;
    private Transform arrowContainer;
    private Stack<Arrow> inactiveArrows = new Stack<Arrow>();
    private List<Arrow> activeArrows = new List<Arrow>();

    public ArrowPool(Arrow arrow, GameObject originPoint, Transform arrowContainer)
    {
        this.arrowPrefab = arrow;
        this.originPoint = originPoint;
        this.arrowContainer = arrowContainer;
    }

    public Arrow GetArrow()
    {
        Arrow arrowFromPool;
        if (inactiveArrows.Count > 0)
        {
            arrowFromPool = inactiveArrows.Pop();
        }
        else
        {
            arrowFromPool = Object.Instantiate(arrowPrefab, arrowContainer);
            arrowFromPool.SetPool(this);
        }

        arrowFromPool.transform.position = originPoint.transform.position;
        arrowFromPool.gameObject.SetActive(true);
        activeArrows.Add(arrowFromPool);
        return arrowFromPool;
    }

    public void AddInactiveArrowToThePool(Arrow inactiveArrow)
    {
        activeArrows.Remove(inactiveArrow);
        inactiveArrow.gameObject.SetActive(false);
        inactiveArrows.Push(inactiveArrow);
    }
}

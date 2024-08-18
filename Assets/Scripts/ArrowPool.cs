using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    private Arrow arrowPrefab;
    private Stack<Arrow> inactiveArrows = new Stack<Arrow>();
    private List<Arrow> activeArrows = new List<Arrow>();

    public ArrowPool(Arrow arrow)
    {
        this.arrowPrefab = arrow;
    }

    public Arrow GetArrow()
    {
        if (inactiveArrows.Count > 0)
        {
            Arrow arrowFromPool = inactiveArrows.Pop();
            arrowFromPool.gameObject.SetActive(true);
            return arrowFromPool;
        }

        Arrow newArrow = Object.Instantiate(arrowPrefab);
        newArrow.gameObject.SetActive(true);
        return newArrow;
    }

    public void AddInactiveArrowToThePool(Arrow inactiveArrow)
    {
        inactiveArrow.gameObject.SetActive(false);
        inactiveArrows.Push(inactiveArrow);
    }
}

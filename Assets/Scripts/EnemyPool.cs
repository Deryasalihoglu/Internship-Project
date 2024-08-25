using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{
    private Enemy enemyPrefab;
    private GameObject enemyOriginPoint;
    private Transform enemyContainer;
    private Stack<Enemy> inactiveEnemies = new Stack<Enemy>();
    private List<Enemy> activeEnemies = new List<Enemy>();
    private Tower targetTower;

    public EnemyPool(Enemy enemyPrefab, Tower tower, GameObject enemyOriginPoint, Transform enemyContainer)
    {
        this.enemyPrefab = enemyPrefab;
        this.targetTower = tower;
        this.enemyOriginPoint = enemyOriginPoint; 
        this.enemyContainer = enemyContainer;
    }

    public void AddDefeatedEnemyToPool(Enemy defeatedEnemy)
    {
        activeEnemies.Remove(defeatedEnemy);
        defeatedEnemy.gameObject.SetActive(false);
        inactiveEnemies.Push(defeatedEnemy);
    }

    public Enemy GetEnemy()
    {
        Enemy enemyFromPool;
        if (inactiveEnemies.Count > 0)
        {
            enemyFromPool = inactiveEnemies.Pop();
        }
        else
        {
            enemyFromPool = Object.Instantiate(enemyPrefab, enemyContainer);
            enemyFromPool.SetPool(this);
        }

        enemyFromPool.transform.position = enemyOriginPoint.transform.position;
        enemyFromPool.gameObject.SetActive(true);
        enemyFromPool.tower = targetTower;
        activeEnemies.Add(enemyFromPool);
        enemyFromPool.OnSpawned();
        return enemyFromPool;
    }
}

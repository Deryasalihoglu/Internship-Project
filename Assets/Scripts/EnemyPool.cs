using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{
    private Enemy enemyPrefab;
    private Stack<Enemy> inactiveEnemies = new Stack<Enemy>();
    private List<Enemy> activeEnemies = new List<Enemy>();
    private Tower targetTower;

    public EnemyPool(Enemy enemyPrefab, Tower tower)
    {
        this.enemyPrefab = enemyPrefab;
        this.targetTower = tower;
    }

    public void AddDefeatedEnemyToPool(Enemy defeatedEnemy)
    {
        defeatedEnemy.gameObject.SetActive(true);
        inactiveEnemies.Push(defeatedEnemy);
    }

    public Enemy GetEnemy()
    {
        if (inactiveEnemies.Count > 0)
        {
            Enemy enemyFromPool = inactiveEnemies.Pop();
            enemyFromPool.gameObject.SetActive(true);
            enemyFromPool.tower = targetTower;
            return enemyFromPool;
        }

        Enemy spawnedEnemy = Object.Instantiate(enemyPrefab);
        spawnedEnemy.tower = targetTower;
        activeEnemies.Add(spawnedEnemy);
        return spawnedEnemy;
    }
}

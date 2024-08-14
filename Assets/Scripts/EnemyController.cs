using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Tower tower;
    [SerializeField] private float spawnCooldown;
    private float timeSinceLastSpawn;
    private bool isTowerAlive = true;
    private EnemyPool pool;

    private void Start()
    {
        pool = new EnemyPool(enemyPrefab, tower);
        GameController.Instance.OnTowerDestroyed += OnTowerDestroyed;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (isTowerAlive && timeSinceLastSpawn > spawnCooldown)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        pool.GetEnemy();
        timeSinceLastSpawn = 0f;
    }

    private void OnTowerDestroyed()
    {
        isTowerAlive = false;
    }
}

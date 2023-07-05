using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<EnemyProperties> enemiesProperties;
    public List<BulletProperties> enemyBulletProperties;

    [SerializeField] private GameObject _go;
    public void StartGame()
    {
        foreach (var enemy in enemiesProperties)
        {
            Pool pool = new Pool();
            pool.prefab = enemy.EnemyPrefab;
            pool.tag = enemy.Tag;
            pool.size = enemy.NumberSpawn;
            ObjectPooler.Instance.Initialize(pool);
        }

        foreach (var bullet in enemyBulletProperties)
        {
            Pool pool = new Pool();
            pool.prefab = bullet.BulletPrefab;
            pool.tag = bullet.Tag;
            pool.size = bullet.NumberSpawn;
            ObjectPooler.Instance.Initialize(pool);
        }
        InvokeRepeating("Spawn",0, 1f);
    }

    public void Spawn()
    {
        if (GameManager.instance.isGameActive && !GameManager.instance.miniBossActive)
        {
            float XspawnRange = 2.5f;
            float YspawnPosition = 5.5f;
            Vector2 SpawnPosition = new Vector2(Random.Range(-XspawnRange, XspawnRange), YspawnPosition);
            EnemyProperties enemyProperties = enemiesProperties[Random.Range(0, enemiesProperties.Count)];

            _go = ObjectPooler.Instance.SpawnFromPool(enemyProperties.Tag, SpawnPosition, Quaternion.identity);
            
            IPooledObject pooledObj = _go.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
                pooledObj.Speed = enemyProperties.Speed;
            }
        }
    }
}

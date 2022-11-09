using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public ObstacleProperties obstacle;
    [SerializeField] private ObstacleProperties _obstacle;
   
    public void Start()
    {
        Pool pool = new Pool();
        pool.tag = obstacle.Tag;
        pool.prefab = obstacle.ObstaclePrefab;
        pool.size = obstacle.NumberSpawn;
        ObjectPooler.Instance.Initialize(pool);
        InvokeRepeating("Spawn", 0f, 5f);
    }

    public void Spawn()
    {
        if (GameManager.instance.isGameActive && !GameManager.instance.miniBossActive)
        {
            Vector2 SpawnPosition = new Vector2(Random.Range(-2.5f, 2.5f), 5.5f);

            GameObject _obstacle = ObjectPooler.Instance.SpawnFromPool(obstacle.Tag, SpawnPosition, Quaternion.identity);

            IPooledObject pooledObj = _obstacle.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
                pooledObj.Speed = obstacle.Speed;
                pooledObj.Boundary = obstacle.Boundary;
            }
        }
    }
}

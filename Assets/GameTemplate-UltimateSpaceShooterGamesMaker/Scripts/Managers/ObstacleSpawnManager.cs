using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class ObstacleSpawnManager : MonoBehaviour
	{
		public ObstacleProperties obstacle;

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
			if (!GameManager.instance.isGameActive || GameManager.instance.miniBossActive) return;
			float XspawnRange = 2.5f;
			float YspawnPosition = 5.5f;
			Vector2 SpawnPosition = new Vector2(Random.Range(-XspawnRange, XspawnRange), YspawnPosition);

			GameObject _obstacle =
				ObjectPooler.Instance.SpawnFromPool(obstacle.Tag, SpawnPosition, Quaternion.identity);

			IPooledObject pooledObj = _obstacle.GetComponent<IPooledObject>();
			if (pooledObj == null) return;
			pooledObj.OnObjectSpawn();
			pooledObj.Speed = obstacle.Speed;
		}
	}
}

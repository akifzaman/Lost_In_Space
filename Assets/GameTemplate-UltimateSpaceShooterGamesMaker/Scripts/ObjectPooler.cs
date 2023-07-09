using System.Collections.Generic;
using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class ObjectPooler : MonoBehaviour
	{
		public static ObjectPooler Instance;

		#region Singleton

		public void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				DestroyImmediate(gameObject);
			}
		}

		#endregion

		[SerializeField] private List<Pool> pools;
		public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
		[SerializeField] private string _tag;

		public void Initialize(Pool pool)
		{
			pools.Add(pool);

			Queue<GameObject> objectPool = new Queue<GameObject>();

			for (int i = 0; i < pool.size; i++)
			{
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}

			poolDictionary.Add(pool.tag, objectPool);
		}

		public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
		{
			if (!poolDictionary.ContainsKey(tag))
			{
				Debug.LogError("Doesn't exist");
				return null;
			}

			GameObject objectToSpawn = poolDictionary[tag].Dequeue();

			objectToSpawn.SetActive(true);
			objectToSpawn.transform.position = position;
			objectToSpawn.transform.rotation = rotation;

			IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

			if (pooledObj != null)
			{
				pooledObj.OnObjectSpawn();
			}

			poolDictionary[tag].Enqueue(objectToSpawn);

			return objectToSpawn;
		}
	}

}
using System;
using System.Collections;
using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class Shooting : MonoBehaviour
	{
		public bool CanShoot;

		public Transform SpawnPosition;
		public AudioClip bulletSound;

		[SerializeField] private AudioSource shootingAudio;
		[SerializeField] private BulletProperties _bullet;

		public void Initialize(BulletProperties bullet)
		{
			_bullet = bullet;
			Pool pool = new Pool();
			pool.prefab = _bullet.BulletPrefab;
			pool.tag = _bullet.Tag;
			pool.size = _bullet.NumberSpawn;
			ObjectPooler.Instance.Initialize(pool);
		}

		private void Start()
		{
			shootingAudio = GetComponent<AudioSource>();
		}

		public IEnumerator Fire(BulletProperties bullet)
		{
			while (GameManager.instance.isGameActive && CanShoot)
			{
				_bullet = bullet;
				yield return new WaitForSeconds(bullet.BulletDelay);
				GameObject go = ObjectPooler.Instance.SpawnFromPool(bullet.Tag, SpawnPosition.position,
					bullet.BulletPrefab.transform.rotation);
				IPooledObject pooledObj = go.GetComponent<IPooledObject>();
				if (pooledObj != null)
				{
					pooledObj.OnObjectSpawn();
					pooledObj.Speed = _bullet.Speed;
				}

				shootingAudio.PlayOneShot(bulletSound, 0.04f);
			}
		}

	}
}

using System.Collections.Generic;
using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class BulletPool : MonoBehaviour
	{
		public static BulletPool bulletPoolInstance;

		[SerializeField] private GameObject pooledBullet1;
		[SerializeField] private GameObject pooledBullet2;
		private bool notEnoughBulletInPool = true;
		private List<GameObject> bullets;

		private void Awake()
		{
			bulletPoolInstance = this;
		}

		void Start()
		{
			bullets = new List<GameObject>();
		}

		public GameObject GetBullet1()
		{
			if (bullets.Count > 0)
			{
				for (int i = 0; i < bullets.Count; i++)
				{
					if (!bullets[i].activeInHierarchy)
					{
						return bullets[i];
					}
				}
			}

			if (notEnoughBulletInPool)
			{
				GameObject bul = Instantiate(pooledBullet1);
				bul.SetActive(false);
				bullets.Add(bul);
				return bul;
			}

			return null;
		}

		public GameObject GetBullet2()
		{
			if (bullets.Count > 0)
			{
				for (int i = 0; i < bullets.Count; i++)
				{
					if (!bullets[i].activeInHierarchy)
					{
						return bullets[i];
					}
				}
			}

			if (notEnoughBulletInPool)
			{
				GameObject bul = Instantiate(pooledBullet2);
				bul.SetActive(false);
				bullets.Add(bul);
				return bul;
			}

			return null;
		}
	}
}
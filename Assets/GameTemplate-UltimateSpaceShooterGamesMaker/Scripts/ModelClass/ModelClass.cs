using System;
using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class ModelClass
	{

	}

	[Serializable]
	public class BulletProperties
	{
		public int NumberSpawn;
		public string Tag;
		public float BulletDelay;
		public float Speed;
		public float Boundary;
		public float Angle;
		public GameObject BulletPrefab;
	}

	[Serializable]
	public class Player
	{
		public float speed;
		public float health;
		public int superSplashCounter;
	}

	[Serializable]
	public class EnemyProperties
	{
		public int NumberSpawn;
		public string Tag;
		public float EnemySpawnDelay;
		public float Speed;
		public float Health;
		public float Boundary;
		public GameObject EnemyPrefab;
	}

	[Serializable]
	public class ObstacleProperties
	{
		public int NumberSpawn;
		public string Tag;
		public float ObstacleSpawnDelay;
		public float Speed;
		public float Health;
		public float Boundary;
		public GameObject ObstaclePrefab;
		public GameObject ExplotionAnimPrefab;

	}

	[Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size;
	}
}
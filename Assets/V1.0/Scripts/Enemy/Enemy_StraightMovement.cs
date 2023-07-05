using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class Enemy_StraightMovement : Enemy
	{
		private void Update()
		{
			if (!GameManager.instance.isGameActive) return;
			MoveDown();
		}

		private void OnEnable()
		{
			shooting = GetComponent<Shooting>();
			shooting.CanShoot = !GameManager.instance.OnSpeedUp;
		}

		public override void OnObjectSpawn()
		{
			enemyAudioSource = GetComponent<AudioSource>();
			shooting.CanShoot = !GameManager.instance.OnSpeedUp;
			StartCoroutine(shooting.Fire(bulletProperties));
		}
	}
}

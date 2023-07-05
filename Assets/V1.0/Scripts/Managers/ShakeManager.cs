using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class ShakeManager : MonoBehaviour
	{
		public float speed, amount, duration;
		private Vector3 startPos, shakePos;

		void Start()
		{
			shakePos = startPos = transform.position;
			speed = 2.34f;
			amount = 0.06f;
			duration = 5.0f;
		}

		void Update()
		{

			if (GameManager.instance.isShakeActive && duration > 0)
			{
				Shake();
			}
			else
			{
				transform.position =
					Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * Mathf.Abs(speed));
			}
		}

		void Shake()
		{
			duration -= Time.deltaTime;
			if (transform.position == shakePos)
			{
				shakePos = startPos + new Vector3(Random.Range(-amount, amount), Random.Range(-amount, amount), 0);
			}
			else
			{
				transform.position =
					Vector3.MoveTowards(transform.position, shakePos, Time.deltaTime * Mathf.Abs(speed));
			}
		}
	}
}

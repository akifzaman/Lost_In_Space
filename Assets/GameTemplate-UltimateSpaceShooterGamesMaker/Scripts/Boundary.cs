using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class Boundary : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D other) => other.gameObject.SetActive(false);
	}
}

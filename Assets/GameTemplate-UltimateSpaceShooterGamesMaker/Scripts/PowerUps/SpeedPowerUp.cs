using System.Collections;
using UnityEngine;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class SpeedPowerUp : PowerUp
	{
		public override PlayerController Player { get; set; }

		public override void UsePowerUp()
		{
			GameManager.instance.OnSpeedUp = true;
			GameManager.instance.SpeedPowerUp.Invoke();
		}

	}
}

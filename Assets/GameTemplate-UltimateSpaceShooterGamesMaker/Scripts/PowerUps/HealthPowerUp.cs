using System.Collections;

namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public class HealthPowerUp : PowerUp
	{
		public override PlayerController Player { get; set; }

		public override void UsePowerUp()
		{
			Player.UpdateSlider(0);
		}
	}
}

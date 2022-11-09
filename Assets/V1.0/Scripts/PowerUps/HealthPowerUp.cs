using System.Collections;

public class HealthPowerUp : PowerUp
{
    public override PlayerController Player { get; set; }

    public override void UsePowerUp()
    {
        Player.UpdateSlider(0);
    }
}

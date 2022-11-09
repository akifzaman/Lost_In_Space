using System.Collections;

public class ShieldPowerUp : PowerUp
{
    public override PlayerController Player { get; set; }

    public override void UsePowerUp()
    {
        Player.ActivateShield();
    }
}
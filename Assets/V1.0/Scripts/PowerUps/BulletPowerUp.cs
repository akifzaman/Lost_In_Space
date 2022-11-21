public class BulletPowerUp : PowerUp
{
    public override PlayerController Player { get; set; }
    public override void UsePowerUp()
    {
        Player.shooting.CanShoot = false;
        Player.SetDoubleBullet();
    }

}

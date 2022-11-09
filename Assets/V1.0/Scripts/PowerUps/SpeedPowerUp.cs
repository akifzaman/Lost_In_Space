using System.Collections;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    private BackgroundController moveDownController;

    public override PlayerController Player { get; set; }


    void Start()
    {
        moveDownController = GameObject.Find("Background").GetComponent<BackgroundController>();
    }

    public override void UsePowerUp()
    {
        GameManager.instance.OnSpeedUp = true;
        Debug.Log("invoked from speedPowerUp");
        if (moveDownController.speed == 10)
        {
            moveDownController.speed *= 5;
        }
        else if (moveDownController.speed == 5)
        {
            moveDownController.speed *= 10;
            GameManager.instance.timeCounter -= 5;
        }
    }

}

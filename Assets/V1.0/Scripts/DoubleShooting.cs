using System.Collections;
using UnityEngine;

public class DoubleShooting : MonoBehaviour
{
    public GameObject bulletTwo;
    public Transform bulletTwoSpawnPosition;
    public float playerBulletTwoDelay = 0.09f;
    public bool isActivatedTwo = false;

    private GameManager gameManager;
   
    void Start()
    {
        StartCoroutine(ShootBulletTwo());
    }

    void Fire2()
    {
        if (isActivatedTwo)
        {
            Instantiate(bulletTwo, bulletTwoSpawnPosition.position, bulletTwo.transform.rotation);
        }
    }
    IEnumerator ShootBulletTwo()
    {
        yield return new WaitForSeconds(playerBulletTwoDelay);
        if (GameManager.instance.isGameActive)
        {
            Fire2();
        }

        StartCoroutine(ShootBulletTwo());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShooting : MonoBehaviour
{
    public GameObject bulletTwo;
    public Transform bulletTwoSpawnPosition;
    public float playerBulletTwoDelay = 0.09f;
    public bool isActivatedTwo = false;

    // Start is called before the first frame update
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
        Fire2();
        StartCoroutine(ShootBulletTwo());
    }
}

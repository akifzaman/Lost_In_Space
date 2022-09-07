using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletOne;
    public Transform bulletOneSpawnPosition;
    public float playerBulletOneDelay = 0.1f;
    public bool isActivatedOne = true;

    //public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBulletOne());
    }
    void Fire1()
    {
        Instantiate(bulletOne, bulletOneSpawnPosition.position, bulletOne.transform.rotation);
    }

    IEnumerator ShootBulletOne()
    {
        yield return new WaitForSeconds(playerBulletOneDelay);
        Fire1();
        if (!isActivatedOne)
        {
            yield break;
        }
        StartCoroutine(ShootBulletOne());
    }
}

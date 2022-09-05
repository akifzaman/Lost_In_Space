using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Fire()
    {
        Instantiate(bullet, bulletSpawnPosition.position, bullet.transform.rotation);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.10f);
        Fire();
        StartCoroutine(Shoot());
    }
}

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
        //Instantiate(bullet, bulletSpawnPosition.position, Quaternion.Euler(new Vector3(0f, 0f, 180f)));
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        Fire();
        StartCoroutine(Shoot());
    }
}

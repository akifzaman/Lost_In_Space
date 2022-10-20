using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject bulletPrefab;
    public Transform SpawnPosition;
    private float bulletDelay;
    public bool isActivatedOne = true;
    public AudioClip bulletSound;

    private AudioSource shootingAudio;

    void StartShooting()
    {
        StartCoroutine(ShootBulletOne());
        StartCoroutine(Fire());
        shootingAudio = GetComponent<AudioSource>();
    }

    public void Initialize(BulletProperties bullet)
    {
        bulletPrefab = bullet.BulletPrefab;
        bulletDelay = bullet.BulletDelay;
        StartShooting();
    }


    void Fire1()
    {
        Instantiate(bulletPrefab, SpawnPosition.position, bulletPrefab.transform.rotation);
    }

    IEnumerator ShootBulletOne()
    {
        yield return new WaitForSeconds(bulletDelay);
        if (GameManager.instance.isGameActive)
        {
            Fire1();
        }
        if (!isActivatedOne)
        {
            yield break;
        }
        StartCoroutine(ShootBulletOne());
    }
    void FireSound()
    {
        if (GameManager.instance.isGameActive)
        {
            shootingAudio.PlayOneShot(bulletSound, 0.04f);
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.2f);
        FireSound();
        StartCoroutine(Fire());
    }

}

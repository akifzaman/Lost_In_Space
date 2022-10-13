using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletOne;
  
    public Transform bulletOneSpawnPosition;
    public float playerBulletOneDelay = 0.1f;
    public bool isActivatedOne = true;

    private GameManager gameManager;

    private AudioSource shootingAudio;
    public AudioClip bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBulletOne());
        StartCoroutine(Fire());
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        shootingAudio = GetComponent<AudioSource>();
    }

    void Fire1()
    {
        Instantiate(bulletOne, bulletOneSpawnPosition.position, bulletOne.transform.rotation);
        //
    }

    IEnumerator ShootBulletOne()
    {
        yield return new WaitForSeconds(playerBulletOneDelay);
        if (gameManager.isGameActive)
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
        if (gameManager.isGameActive)
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
